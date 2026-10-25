using System;

namespace Algodat {
    public class Point {
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
            this.X = x;
            this.Y = y;
        }
    
        private void CheckConstrain(int val)
        {
            if(val < 0) throw new ArgumentOutOfRangeException("Value was negative");
        }

        public override string ToString()
        {
            return $"X: {this.X} Y: {this.Y}";
        }

        protected bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}