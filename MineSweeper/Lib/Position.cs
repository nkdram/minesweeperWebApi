using System;

namespace MineSweeper.Lib
{
    public class Position
    {
        private int _x = 0, _y = 0;

        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Position(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
    }
}
