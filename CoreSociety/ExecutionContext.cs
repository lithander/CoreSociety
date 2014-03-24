using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoreSociety
{
    public class ExecutionContext
    {
        private Random _rnd = new Random();
        private byte _ip;
        private ushort _instr;
        private ushort[] _mem = null;
        private ushort[] _tgt = null;
        private Core _core;
        private Core _target;

        public int Score = 0;

        public int InstructionBaseCost = 1;

        public void ConsumeEnergyUntilExecute(Core core, Core target)
        {
            //spend this energy!
            SetContext(core, target);
            int cost = GetNextInstructionCost();
            if (core.Energy > 0)
            {
                int available = core.Energy;
                int needed = Math.Max(1, cost - core.Charge);
                int spent = Math.Min(needed, available);
                core.Charge = (byte)(core.Charge + spent);
                core.Energy = (byte)(core.Energy - spent);
            }
            if (core.Charge >= cost)
            {
                core.InstructionPointer = Execute();
                core.Charge = 0;
            }
        }

        public void ConsumeOneEnergy(Core core, Core target)
        {
            //spend this energy!
            SetContext(core, target);
            if(core.Energy > 0)
            {
                core.Charge++;
                core.Energy--;
            }
            if(core.Charge >= GetNextInstructionCost())
            {
                core.InstructionPointer = Execute();
                core.Charge = 0;
            }
        }

        public int GetNextInstructionCost(Core core)
        {
            _core = core;
            _mem = core.Data;
            _ip = core.InstructionPointer;
            _instr = _mem[_ip];
            return GetNextInstructionCost();
        }

        public void Execute(Core core, Core target)
        {
            SetContext(core, target);
            core.Charge = 0;
            core.InstructionPointer = Execute();
        }
        
        public void ExecuteMultiple(Core core, Core target, int numInstructions)
        {
            SetContext(core, target);
            while (numInstructions-- > 0)
            {
                _ip = Execute();
                _instr = _mem[_ip];
            }
            core.InstructionPointer = _ip;
        }

        private void SetContext(Core core, Core target)
        {
            _core = core;
            _target = target;
            _mem = core.Data;
            _tgt = target.Data;
            _ip = core.InstructionPointer;
            _instr = _mem[_ip];
        }

        private int GetNextInstructionCost()
        {
            ushort group = (ushort)(_instr & 0xF000);
            if (group == 0xB000 || group == 0xC000) // ENERGY or SCORE GROUP
            {
                if((_instr & 0xFE00) == (int)Opcode.DSE)
                    return InstructionBaseCost; //decrease shield energy does not require charging
                else
                    return (byte)Math.Max(InstructionBaseCost, GetTargetValue());
            }
            else
                return InstructionBaseCost;
        }

        private byte GetTargetAddress()
        {
            byte target = (byte)(_instr & 0xFF);
            if ((_instr & Instruction.TARGET_NO_ADDRESS) == Instruction.TARGET_NO_ADDRESS)
                target = (byte)(_mem[target] & 0xFF);

            return target;
        }

        private ushort GetTargetValue()
        {
            byte target = (byte)(_instr & 0xFF);
            if ((_instr & Instruction.TARGET_NO_ADDRESS) == Instruction.TARGET_NO_ADDRESS)
                return target;
            else
                return _mem[target];
        }

        private byte GetParamAdress()
        {
            ushort param = _mem[_ip + 1];
            //result.ParamWord |= (ushort)(indir << 8);
            byte addr = (byte)param;
            int indir = param >> 8;
            while (indir-- > 0)
                addr = (byte)_mem[addr];

            return addr;
        }

        private ushort GetParamValue()
        {
            if ((_instr & Instruction.PARAM_NO_NUMERAL) == Instruction.PARAM_NO_NUMERAL)
            {
                byte target = GetParamAdress();
                return _mem[target];
            }
            else
                return _mem[_ip + 1];
        }

        private byte Execute()
        {
            switch (_instr & 0xF000)
            {
                case 0x1000:
                    MemOps();
                    return (byte)(_ip + 1);
                case 0x2000:
                    CopyOps();
                    return (byte)(_ip + 2);
                case 0x3000:
                case 0x4000:
                case 0x5000:
                    MathOps();
                    return (byte)(_ip + 2);
                case 0x6000:
                    if (ConditionalOps())
                        return (byte)(_ip + 1);
                    else
                        return (byte)(_ip + 2);
                case 0x7000:
                    if (ConditionalParamOps())
                        return (byte)(_ip + 2);
                    else
                        return (byte)(_ip + 3);
                case 0x8000:
                    if ((_instr & 0xFE00) == (int)Opcode.JMP)
                        return (byte)(_ip + GetTargetValue());
                    if ((_instr & 0xFE00) == (int)Opcode.NXT)
                        return GetTargetAddress();
                    if ((_instr & 0xFE00) == (int)Opcode.SIP && _target.Shield == 0)
                        _target.InstructionPointer = GetTargetAddress();
                    return (byte)(_ip + 1);
                case 0x9000:
                    QueryOps();
                    return (byte)(_ip + 1);
                case 0xA000: //MODE
                    ushort val = GetTargetValue();
                    if (val < 4)
                        _core.Target = (Core.Focus)(val);
                    else
                        _core.Target = Core.Focus.Self;
                    return (byte)(_ip + 1);
                case 0xB000:
                    EnergyOps();
                    return (byte)(_ip + 1);
                case 0xC000:
                    ScoreOps();
                    return (byte)(_ip + 1);
                default:
                    return (byte)(_ip + 1);
            }
        }

        private void ScoreOps()
        {
            byte value = (byte)GetTargetValue();
            switch (_instr & 0xFE00)
            {
                case (int)Opcode.ISC:
                    Score += value;
                    break;
                case (int)Opcode.DSC:
                    Score -= value;
                    if (Score < 0)
                        Score = 0;
                    break;
            }
        }

        private void EnergyOps()
        {
            byte value = (byte)GetTargetValue();
            switch (_instr & 0xFE00)
            {
                case (int)Opcode.RSV:
                    _core.Energy = (byte)Math.Min(255, _core.Energy + value);
                    break;
                case (int)Opcode.ISE:
                    _core.Shield = (byte)Math.Min(255, _core.Shield + value);
                    break;
                case (int)Opcode.DSE:
                    _core.Shield = (byte)Math.Max(0, _core.Shield - value);
                    break;
                case (int)Opcode.BST:
                    _target.Energy = (byte)Math.Min(255, _target.Energy + value);
                    break;
                case (int)Opcode.WKN:
                    byte maxWeakenValue = Math.Min(value, (byte)15);
                    byte shieldDmg = (byte)Math.Min(maxWeakenValue, _target.Shield);
                    byte coreDmg = (byte)(maxWeakenValue - shieldDmg);
                    _target.Shield = (byte)Math.Max(0, _target.Shield - shieldDmg);
                    _target.Energy = (byte)Math.Max(0, _target.Energy - coreDmg);
                    break;
            }
        }

        private void QueryOps()
        {
            byte target = GetTargetAddress();
            switch (_instr & 0xFE00)
            {
                case (int)Opcode.QIP:
                    _mem[target] = _target.InstructionPointer;
                    break;
                case (int)Opcode.QUE:
                    _mem[target] = _target.Energy;
                    break;
                case (int)Opcode.QSE:
                    _mem[target] = _target.Shield;
                    break;
                case (int)Opcode.QCE:
                    _mem[target] = _target.Charge;
                    break;
                case (int)Opcode.QTC:
                    _mem[target] = (byte)_target.Target;
                    break;
            }
        }

        private bool ConditionalOps()
        {
            byte target = GetTargetAddress();
            switch (_instr & 0xFE00)
            {
                case (int)Opcode.IFZ:
                    return _mem[target] == 0;
                case (int)Opcode.IFS:
                    return _mem[target] != 0;
                case (int)Opcode.IFR:
                    return _mem[target] > (ushort)_rnd.Next(ushort.MaxValue);
            }
            return false;
        }

        private bool ConditionalParamOps()
        {
            byte target = GetTargetAddress();
            ushort value = GetParamValue();
            switch (_instr & 0xFC00)
            {
                case (int)Opcode.IFE:
                    return _mem[target] == value;
                case (int)Opcode.IFN:
                    return _mem[target] != value;
                case (int)Opcode.IFG:
                    return _mem[target] > value;
                case (int)Opcode.IFL:
                    return _mem[target] < value;
            }
            return false;
        }

        private void MathOps()
        {
            byte target = GetTargetAddress();
            ushort value = GetParamValue();
            switch (_instr & 0xFC00)
            {
                case (int)Opcode.ADD:
                    _mem[target] += value;
                    break;
                case (int)Opcode.SUB:
                    _mem[target] -= value;
                    break;
                case (int)Opcode.MUL:
                    _mem[target] *= value;
                    break;
                case (int)Opcode.DIV:
                    _mem[target] /= value;
                    break;
                case (int)Opcode.MOD:
                    _mem[target] %= value;
                    break;
                case (int)Opcode.MAX:
                    _mem[target] = Math.Max(_mem[target], value);
                    break;
                case (int)Opcode.MIN:
                    _mem[target] = Math.Min(_mem[target], value);
                    break;
                case (int)Opcode.AND:
                    _mem[target] &= value;
                    break;
                case (int)Opcode.IOR:
                    _mem[target] |= value;
                    break;
                case (int)Opcode.XOR:
                    _mem[target] ^= value;
                    break;
            }
        }

        private void CopyOps()
        {
            byte target = GetTargetAddress();
            switch (_instr & 0xFC00)
            {
                case (int)Opcode.SET:
                    _mem[target] = GetParamValue();
                    break;
                case (int)Opcode.RDW:
                    _mem[target] = _tgt[GetParamAdress()];
                    break;
                case (int)Opcode.STW:
                    if (_target.Shield == 0)
                         _tgt[target] = GetParamValue();
                    break;
            }
        }

        private void MemOps()
        {
            byte target = GetTargetAddress();
            switch (_instr & 0xFE00)
            {
                case (int)Opcode.INC:
                    _mem[target]++;
                    break;
                case (int)Opcode.DEC:
                    _mem[target]--;
                    break;
                case (int)Opcode.NOT:
                    _mem[target] = (ushort)(~_mem[target]);
                    break;
                case (int)Opcode.RND:
                    _mem[target] = (ushort)(_rnd.Next(ushort.MaxValue));
                    break;
                case (int)Opcode.SQT:
                    _mem[target] = (ushort)Math.Sqrt((double)_mem[target]);
                    break;

            }
        }
    }
}
