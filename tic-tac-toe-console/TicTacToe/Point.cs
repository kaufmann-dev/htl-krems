using System;

namespace TicTacToe
{
    public class Point
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set
            {
                CheckConstrain(value);
                _x = value;
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                CheckConstrain(value);
                _y = value;
            }
        }

        public Point(int x, int y)
        {
            CheckConstrain(x);
            CheckConstrain(y);
            this._x = x;
            this._y = y;
        }

        private void CheckConstrain(int value)
        {
            if (value < 0 || value > 2)
            {
                throw new ArgumentException();
            }
        }
    }
}