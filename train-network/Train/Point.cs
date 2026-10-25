using System;
using System.Collections.Generic;

namespace Train {
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
            if(val < 0) throw new ArgumentOutOfRangeException("value was negative, not allow");
        }

        protected bool Equals(Point other)
        {
            return _x == other._x && _y == other._y;
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
            return HashCode.Combine(_x, _y);
        }

        public void CalculateRoute(Point p)
        {
            List<Point> Listo = new List<Point>();
            //Listo.Add(new Point(this.X, this.Y));
            
            if (this.Y > p.Y)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (this.X > p.X)
                {
                    //throw new NotImplementedException();
                    for (int i = 0; i < p.Y - this.Y; i++)
                    {
                        Listo.Add(new Point(this.X, this.Y + i));
                    }

                    for (int j = 0; j < this.X - p.X; j++)
                    {
                        Listo.Add(new Point(this.X - j, p.Y));
                    }
                }
                else
                {
                    for (int i = 0; i < p.Y - this.Y; i++)
                    {
                        Listo.Add(new Point(this.X, this.Y + i));
                    }

                    for (int j = 0; j < p.X - this.X; j++)
                    {
                        Listo.Add(new Point(this.X + j, p.Y));
                    }
                }
            }
            Listo.Add(new Point(p.X, p.Y));

            DisplayPointList(Listo);
        }

        public void DisplayPointList(List<Point> points)
        {
            foreach (Point point in points)
            {
                Console.WriteLine("x: " + point.X + " y: " + point.Y);
            }
        }
    }
}