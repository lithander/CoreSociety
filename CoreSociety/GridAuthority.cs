using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoreSociety
{
    public class GridAuthority
    {
        private int _energy;
        public int Energy
        {
            get { return _energy; }
        }

        public int Score
        {
            get { return _exec.Score; }
        }

        private Grid _grid = null;
        private ExecutionContext _exec = new ExecutionContext();
        int _nextEnergyReceiver = 0;
        HashSet<Core> _changeTracker = new HashSet<Core>();

        public delegate void ChangedEventHandler(IEnumerable<Core> changedCores);
        public event ChangedEventHandler Ticked;
        private void NotifyChanges()
        {
            if (Ticked != null)
                Ticked(_changeTracker);
            _changeTracker.Clear();
        }

        public void Init(int energy, Grid grid)
        {
            _grid = grid;
            _energy = energy;
            _exec.Score = 0;
            _nextEnergyReceiver = 0;
            _changeTracker.Clear();
        }

        public void Tick(int budget)
        {
            while (budget > 0 && _energy > 0)
            {
                Core core = _grid.ListOfEntries.Select(e => e.Core).OrderByDescending(c => c.Energy).First();
                if (core.Energy == 0)
                {
                    core = _grid.Entries[_nextEnergyReceiver++].Core;
                    budget--;
                    _energy--;
                    core.Energy++;
                }
                Core target = _grid.GetTargetOf(core);
                _exec.ConsumeEnergyUntilExecute(core, target);
                _changeTracker.Add(core);
                _changeTracker.Add(target);
            }
            NotifyChanges();
        }       

        public StatusFlags GetStatusFlags(Core core)
        {           

            StatusFlags flags = StatusFlags.None;
            ushort instr = core.Memory[core.InstructionPointer];
            if ((instr & 0xFE00) == (int)Opcode.ISC)
                flags = StatusFlags.Yellow;
            else if ((instr & 0xFE00) == (int)Opcode.DSC)
                flags = StatusFlags.Yellow;
            else if ((instr & 0xFE00) == (int)Opcode.ISE)
                flags = StatusFlags.Blue;
            else if ((instr & 0xFE00) == (int)Opcode.BST)
                flags = StatusFlags.Green;
            else if ((instr & 0xFE00) == (int)Opcode.WKN)
                flags = StatusFlags.Red;
            
            return flags;
        }
    }
}
