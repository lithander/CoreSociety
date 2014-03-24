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
    public partial class DeckView : UserControl
    {
        public DeckView()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            RebuildBuffer();
        }

        private List<Listing> _data = null;
        public List<Listing> Data
        {
            get { return _data; }
            set 
            {
                Unsubscribe(_data);
                _data = value;
                Subscribe(_data);
                RebuildBuffer(); 
            }
        }

        private void Unsubscribe(List<Listing> listings)
        {
            if (listings != null)
                foreach (Listing ls in listings)
                    ls.Changed -= OnListingChanged;
        }

        private void Subscribe(List<Listing> listings)
        {
            if(listings != null)
                foreach(Listing ls in listings)
                    ls.Changed += OnListingChanged;
        }

        void OnListingChanged(Listing sender)
        {
            Render(sender);
        }

        private Core _core = new Core();
        private CoreView _coreView = new CoreView();
        private Bitmap _buffer = null;

        private int _coreMargin = 3;
        public int CoreMargin
        {
            get { return _coreMargin; }
            set { _coreMargin = value; RebuildBuffer(); }
        }

        private void ResetOffset()
        {
            if (_buffer != null)
            {
                _offset = (Width - _buffer.Width) / 2;
            }
        }

        private int _offset = 0;

        public int OffsetX
        {
            get { return _offset; }
            set { _offset = value; Invalidate(); }
        }

        public void RebuildBuffer()
        {
            _buffer = null;
            if (_data != null)
            {
                int bufferWidth = _data.Count * (_coreView.Width + _coreMargin);
                int bufferHeight = _coreView.Height;
                _buffer = new Bitmap(bufferWidth, bufferHeight);

                Graphics gfx = Graphics.FromImage(_buffer);
                int i = 0;
                foreach(Listing listing in _data)
                {
                    _core.ClearMemory();
                    listing.Compile(_core);
                    _coreView.RenderBasic(_core, listing.Color);
                    gfx.DrawImage(_coreView.Image, i++ * (_coreView.Width + _coreMargin), 0);
                }
            }
            Invalidate();
        }

        public void Render(Listing listing)
        {
            if (_data != null && _buffer != null)
            {
                Graphics gfx = Graphics.FromImage(_buffer);
                int i = _data.IndexOf(listing);
                _core.ClearMemory();
                listing.Compile(_core);
                _coreView.RenderBasic(_core, listing.Color);
                gfx.DrawImage(_coreView.Image, i * (_coreView.Width + _coreMargin), 0);
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
                gfx.DrawImage(_buffer, _offset, 0);
            }
        }

        public Listing Pick(Point pixel)
        {
            if (_data == null)
                return null;

            int index = pixel.X / (_coreView.Width + _coreMargin);
            if (index < _data.Count)
                return _data[index];
            else
                return null;
        }
    }
}
