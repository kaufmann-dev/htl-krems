using System;
using System.Collections.Generic;

namespace combatSimOOP {
    public class Point {
        
        private int _x;
        private int _y;

        public Point(int x, int y) {
            _x = x;
            _y = y;
        }

        public int X {
            get => _x;
            set => _x = value;
        }

        public int Y {
            get => _y;
            set => _y = value;
        }

        public string Info() {
            return $"x: {_x} y: {_y}";
        }

        public List<Point> CalculateControlZone() {
            List<Point> points = new List<Point>();

            for (int i = _x - 1; i <= _x + 1; i++) {
                for (int j = _y - 1; j <= _y + 1; j++) {
                    if(i != _x || j != _y)
                        points.Add(new Point(i,j));
                }
            }
            
            return points;
        }

        public bool IsEqual(Point p) {
            return this._x == p.X && this._y == p.Y;
        }

        public EHorizontalPosition DetermineHorizontalPosition(Point p) {
            if (this._x < p.X)
                return EHorizontalPosition.TO_THE_LEFT;

            if (this._x > p.X)
                return EHorizontalPosition.TO_THE_RIGHT;

            return EHorizontalPosition.EQUAL;
        }

        public EVerticalPosition DetermineVerticalPosition(Point p) {
            if (this._y < p.Y) 
                return EVerticalPosition.BELOW;


            if (this._y > p.Y)
                return EVerticalPosition.ABOVE;

            return EVerticalPosition.EQUAL;
        }

        public List<Point> CalculateRoute(Point p) {
            List<Point> route = new List<Point>();

            if (IsEqual(p)) {
                return route;
            }

            if (DetermineHorizontalPosition(p) == EHorizontalPosition.TO_THE_LEFT || DetermineHorizontalPosition(p) == EHorizontalPosition.EQUAL) {
                for (int i = X + 1; i <= p.X; i++) {
                    route.Add(new Point(i, Y));
                }
                
                if(DetermineVerticalPosition(p) == EVerticalPosition.BELOW)
                    for (int i = Y + 1; i <= p.Y; i++) {
                        route.Add(new Point(p.X, i));
                    }

                if (DetermineVerticalPosition(p) == EVerticalPosition.ABOVE)
                    for (int i = Y - 1; i >= p.Y; i--) {
                        route.Add(new Point(p.X, i));
                    }
            }
            
            if (DetermineHorizontalPosition(p) == EHorizontalPosition.TO_THE_RIGHT) {
                for (int i = X - 1; i >= p.X; i--) {
                    route.Add(new Point(i, Y));
                }
                
                if(DetermineVerticalPosition(p) == EVerticalPosition.BELOW)
                    for (int i = Y + 1; i <= p.Y; i++) {
                        route.Add(new Point(p.X, i));
                    }

                if (DetermineVerticalPosition(p) == EVerticalPosition.ABOVE)
                    for (int i = Y - 1; i >= p.Y; i--) {
                        route.Add(new Point(p.X, i));
                    }
            }
          

            return route;
        }

        public double CalculateDistance(Point p) {
            return Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2));
        }
        
    }
}