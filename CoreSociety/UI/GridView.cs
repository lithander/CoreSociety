using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CoreSociety.UI
{
    public partial class GridView : UserControl
    {
        public GridView()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            RebuildBuffer();
        }
               
        private CoreView _coreView = new CoreView();
        private ExecutionContext _interpreter = new ExecutionContext();
        private Bitmap _buffer = null;

        private int _coreMargin = 3;
        public int CoreMargin
        {
            get { return _coreMargin; }
            set { _coreMargin = value; RebuildBuffer(); }
        }

        private Grid _data = null;
        public Grid Data
        {
            get { return _data; }
            set { _data = value; RebuildBuffer(); ResetOffset(); }
        }

        private void ResetOffset()
        {
            if (_buffer != null)
            {
                _offset.X = (Width - _buffer.Width) / 2;
                _offset.Y = (Height - _buffer.Height) / 2;
            }
        }

        private Point _offset = new Point();

        public int OffsetX
        {
            get { return _offset.X; }
            set { _offset.X = value; Invalidate(); }
        }

        public int OffsetY
        {
            get { return _offset.Y; }
            set { _offset.Y = value; Invalidate(); }
        }

        public void RebuildBuffer()
        {
            _buffer = null;
            if (_data != null)
            {
                int bufferWidth = _data.Width * (_coreView.Width + _coreMargin);
                int bufferHeight = _data.Height * (_coreView.Height + _coreMargin);
                _buffer = new Bitmap(bufferWidth, bufferHeight);

                Graphics gfx = Graphics.FromImage(_buffer);
                for (int y = 0; y < _data.Height; y++)
                    for (int x = 0; x < _data.Width; x++)
                    {
                        Grid.Entry entry = _data.Entries[y, x];
                        _coreView.Render(entry.Core, _interpreter.GetNextInstructionCost(entry.Core), StatusFlags.None, entry.Color);
                        gfx.DrawImage(_coreView.Image, x * (_coreView.Width + _coreMargin), y * (_coreView.Height + _coreMargin));
                    }
            }
            Invalidate();
        }

        public void Render(Core core, StatusFlags statusFlags)
        {
            if (_data != null && _buffer != null)
            {
                Graphics gfx = Graphics.FromImage(_buffer);
                int x, y;
                if(_data.Entries.Find(e => e.Core == core, out x, out y))
                {
                    _coreView.Render(core, _interpreter.GetNextInstructionCost(core), statusFlags, _data.Entries[y, x].Color);
                    gfx.DrawImage(_coreView.Image, x * (_coreView.Width + _coreMargin), y * (_coreView.Height + _coreMargin));
                }
            }
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_buffer != null)
            {
                Graphics gfx = e.Graphics;
                gfx.DrawImage(_buffer, _offset);
            }
        }

        public Point PixelToCell(int x, int y)
        {
            int cx = (x - _offset.X) / (_coreView.Width + _coreMargin);
            int cy = (y - _offset.Y) / (_coreView.Height + _coreMargin);
            return new Point(cx, cy);
        }

        public Point PixelToCell(Point pixel)
        {
            return PixelToCell(pixel.X, pixel.Y);
        }

        public Grid.Entry Pick(Point pixel)
        {
            Point corePos = PixelToCell(pixel);
            if (_data.Entries.Contains(corePos.X, corePos.Y))
                return _data.Entries[corePos.Y, corePos.X];
            else
                return null;
        }
    }
}
