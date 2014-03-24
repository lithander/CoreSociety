using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CoreSociety
{
    public class Grid
    {
        public class Entry
        {
            public Core Core = new Core();
            public Color Color = Color.Black;
            public int ListingID = -1;
        }

        private List<Entry> _entries = null;
        
        private int _width;
        public int Width
        {
            get { return _width; }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
        }

        public IList<Entry> ListOfEntries
        {
            get { return _entries.AsReadOnly(); }
        }

        public Indexer<Entry> Entries
        {
            get { return new Indexer<Entry>(_entries, _width); }
        }

        public Grid(int width, int height)
        {
            int count = width * height;
            _entries = new List<Entry>(count);
            for (int i = 0; i < count; i++)
                _entries.Add(new Entry());
            _width = width;
            _height = height;
        }

        public Core GetTargetOf(Core core)
        {
            int x, y;
            Indexer<Entry> c = new Indexer<Entry>(_entries, _width, ClampMode.Repeat);
            c.Find(e => e.Core == core, out x, out y);
            switch (core.Target)
            {
                case Core.Focus.Up:
                    return c[y - 1, x].Core;
                case Core.Focus.Right:
                    return c[y, x + 1].Core;
                case Core.Focus.Down:
                    return c[y + 1, x].Core;
                case Core.Focus.Left:
                    return c[y, x - 1].Core;
                default:
                    return core;
            }
        }
    }
}
