using System;

namespace Robo
{
    public class Point
    {
        private int _x;
        private int _y;

        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point CalculateNeighbor(EDirectionType direction)
        {
            Point p1 = new Point(this.X, this.Y);
            
            switch (direction)
            {
                case EDirectionType.NORTH:
                    p1.Y -= 1;
                    break;
                case EDirectionType.SOUTH:
                    p1.Y += 1;
                    break;
                case EDirectionType.EAST:
                    p1.X += 1;
                    break;
                case EDirectionType.WEST:
                    p1.X -= 1;
                    break;
                default:
                    throw new Exception();
            }

            return p1;
        }

        public override string ToString()
        {
            return $"X: {this.X}, Y: {this.Y}";
        }

        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
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