using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoreSociety
{
    public enum ClampMode
    {
        Repeat,
        Clamp,
        Wrap
    }
    
    public class Indexer<T>
    {
        private IList<T> _source;
        private int _width = 0;
        private int _height = 0;
        private ClampMode _adressing = ClampMode.Wrap;

        public Indexer(IList<T> source)
        {
            _source = source;
            _width = source.Count;
            _height = 1;
        }

        public Indexer(IList<T> source, ClampMode addressing)
        {
            _source = source;
            _width = source.Count;
            _height = 1;
            _adressing = addressing;
        }

        public Indexer(IList<T> source, int stride)
        {
            _source = source;
            _width = stride;
            _height = source.Count / _width;
        }

        public Indexer(IList<T> source, int stride, ClampMode adressing)
        {
            _source = source;
            _width = stride;
            _height = source.Count / _width;
            _adressing = adressing;
        }

        public bool Contains(int x, int y)
        {
            return (x >= 0 && x < _width && y >= 0 && y < _height);
        }
        
        private void Localize(ref int x, ref int y, ClampMode mode)
        {
            switch(mode)
            {
                case ClampMode.Clamp:
                    y = Math.Min(_height-1, Math.Max(0, y));
                    x = Math.Min(_width-1, Math.Max(0, x));
                    return;
                case ClampMode.Wrap:
                    y += x / _width;
                    x = mod(x, _width);
                    y = mod(y, _height);
                    return;
                case ClampMode.Repeat:
                    x = mod(x, _width);
                    y = mod(y, _height);
                    return;
            }
        }

        private int mod(int x, int m)
        {
            return (x % m + m) % m; //'solve' weirdness of c#'s modulo regarding negative numbers
        }

        public T Get(int x, int y, ClampMode mode)
        {
            Localize(ref x, ref y, mode);
            return _source[y * _width + x];
        }

        public void Set(int x, int y, ClampMode mode, T value)
        {
            Localize(ref x, ref y, mode);
            _source[y * _width + x] = value;
        }

        public bool Find(Func<T, bool> condition, out int x, out int y)
        {
            int idx = _source.IndexOf(_source.First(condition));
            if (idx == -1) //indicates value is not in list
            {
                x = y = -1;
                return false;
            }
            else
            {
                x = idx % _width;
                y = idx / _width;
                return true;
            }
        }


        public T this[int index]
        {
            get { return Get(index, 0, _adressing); }
            set { Set(index, 0, _adressing, value); }
        }

        public T this[int row, int column]
        {
            get { return Get(column, row, _adressing); }
            set { Set(column, row, _adressing, value); }
        }
    }
}
