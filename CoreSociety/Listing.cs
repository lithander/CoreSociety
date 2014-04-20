using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CoreSociety
{
    public class Listing
    {
        public struct IdRange
        {
            public IdRange(byte min, byte max)
            {
                Min = min;
                Max = max;
            }
            public byte Min;
            public byte Max;

            public bool IsValid
            {
                get { return Max > Min && Min >= 0; }
            }
        }


        public Color Color;
        public IdRange Identity;
        private Dictionary<string, byte> _labels = new Dictionary<string, byte>();
        private Dictionary<byte, Instruction> _memMap = new Dictionary<byte, Instruction>();
        private List<string> _lines = new List<string>();

        public delegate void ListingChangedEventHandler(Listing sender);
        public event ListingChangedEventHandler Changed;

        public IList<string> Lines
        {
            get { return _lines.AsReadOnly(); }
        }

        public void Parse(IEnumerable<string> lines)
        {
            _lines = new List<string>(lines);
            _labels.Clear();
            _memMap.Clear();
            InternalParse(lines);
            _memMap.Clear();
            InternalParse(lines);
            if (Changed != null)
                Changed(this);
        }

        private void InternalParse(IEnumerable<string> lines)
        {
            byte location = 0;
            int lineIndex = -1;
            foreach (string line in lines)
            {
                lineIndex++;
                try
                {
                    string ln = line.Trim();
                    //skip empty lines
                    if (ln == "" || ln.StartsWith("/"))
                        continue;
                    //location
                    int b1 = ln.IndexOf('[');
                    int b2 = ln.IndexOf(']');
                    if(b1 > -1 && b2 > b1)
                    {
                        string address = ln.Remove(b2).Remove(0, b1+1);
                        location = ParseByte(address);
                        continue;
                    }
                    //label
                    string[] split = ln.Split(':');
                    if (split.Length == 2)
                    {
                        _labels[split[0].ToUpper()] = location;
                        ln = split[1];
                        continue;
                    }
                    Instruction instr = ParseInstruction(ln, lineIndex, location);
                    //special case. Op is JMP and Target is adress. convert it to relative offset
                    //finish
                    instr.LineNumber = lineIndex;
                    _memMap[location++] = instr;
                    if (instr.HasParam)
                        location++;
                }
                catch { };
            }
        }

        private Instruction ParseInstruction(string line, int lineIndex, byte location)
        {
            Instruction i = new Instruction();
            i.LineNumber = lineIndex;

            line = line.Trim();
            string[] tokens = line.Split(' ');

            //DATA
            if (tokens.Length == 1)
            {
                i.InstructionWord = ParseWord(tokens[0].Trim());
                return i;
            }

            //INSTRUCTION
            string instr = tokens[0].Trim().ToUpper();
            if (Instruction.Mnemonics.ContainsKey(instr))
            {
                i.OpCode = Instruction.Mnemonics[instr];
                i.InstructionWord = (ushort)i.OpCode;
            }
            //TARGET
            string tw = tokens[1].Trim().ToUpper();
            char prefix = tw[0];
            if (prefix == '!' || prefix == '~' || prefix == '?')
            {
                //! = numeral, ~ = indirection
                i.InstructionWord |= Instruction.TARGET_NO_ADDRESS;
                tw = tw.Remove(0, 1);
            }
            byte target = ParseByte(tw);
            //'?' convert target to local offset
            if (prefix == '?')
                target = (byte)(target - location);
            i.InstructionWord |= target;

            //PARAMETER
            if (tokens.Length == 3)
            {
                i.HasParam = true;
                string param = tokens[2].ToUpper();
                if (param[0] == '-')
                    i.ParamWord = (ushort)(-1 * ParseWord(param.Remove(0, 1)));
                else if(param[0] == '!')
                    i.ParamWord = ParseWord(param.Remove(0, 1));
                else
                {
                    //treat param as address value
                    i.InstructionWord = (ushort)(i.InstructionWord | Instruction.PARAM_NO_NUMERAL);
                    byte indir = 0;
                    while (param[indir] == '~')
                        indir++;
                    param = param.Remove(0, indir);
                    i.ParamWord = (ushort)ParseByte(param);
                    i.ParamWord |= (ushort)(indir << 8);
                }
            }
            return i;
        }

        private byte ParseByte(string value)
        {
            byte result;
            if (!byte.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out result))
                _labels.TryGetValue(value, out result);
            return result;
        }

        private ushort ParseWord(string value)
        {
            ushort result;
            if (!ushort.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out result))
            {
                byte addr;
                _labels.TryGetValue(value, out addr);
                return (ushort)addr;
            }
            return result;
        }

        public Instruction GetInstructionAt(byte location)
        {
            if (_memMap.ContainsKey(location))
                return _memMap[location];
            else
                return null;
        }

        public void Compile(Core core)
        {
            foreach (KeyValuePair<byte, Instruction> kv in _memMap)
            {
                byte location = kv.Key;
                Instruction instr = kv.Value;
                core.Memory[location++] = instr.InstructionWord;
                if (instr.HasParam)
                    core.Memory[location++] = instr.ParamWord;
            }
        }

        public void Unload(Core core)
        {
            foreach (KeyValuePair<byte, Instruction> kv in _memMap)
            {
                byte location = kv.Key;
                Instruction instr = kv.Value;
                core.Memory[location++] = 0;
                if (instr.HasParam)
                    core.Memory[location++] = 0;
            }
        }

        public bool MatchIdentity(Core core)
        {
            for (byte location = Identity.Min; location < Identity.Max; location++)
            {
                if (_memMap.ContainsKey(location))
                {
                    Instruction instr = _memMap[location];
                    if (core.Memory[location] != instr.InstructionWord)
                        return false;
                }
            }
            return true;
        }
    }
}
