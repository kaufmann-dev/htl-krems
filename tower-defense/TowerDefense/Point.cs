namespace TowerDefense
{
    public class Point
    {
        private int _x;
        private int _y;
        
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
        
        public string Info()
        {
            return $"x: {_x} y: {_y}";
        }

        public bool IsEqual(Point p1, Point p2)
        {
            if (p1._x == p2._y && p1._y == p2._y)
            {
                return true;
            }

            return false;
        }

        public EHorizentalOrientation DeterminateHorizentalPosition(Point p1, Point p2)
        {
            if (p1._x == p2._x)
            {
                return EHorizentalOrientation.EQUAL;
            }

            if (p1._x < p2._x)
            {
                return EHorizentalOrientation.TO_THE_LEFT;
            }
            
            return EHorizentalOrientation.TO_THE_RIGHT;
        }

        public EVerticalPosition DeterminateVerticalPosition(Point p1, Point p2)
        {
            if (p1._y == p2._y)
            {
                return EVerticalPosition.EQUAL;
            }

            if (p1._y < p2._y)
            {
                return EVerticalPosition.ABOVE;
            }

            return EVerticalPosition.BELOW;
        }

        public Point DeterminateNeighbourY(Point p1, EVerticalPosition v)
        {
            if (v == EVerticalPosition.ABOVE)
            {
                Point p2 = new Point(p1._x, p1._y - 1);
                return p2;
            }
            else
            {
                if (v == EVerticalPosition.BELOW)
                {
                    Point p2 = new Point(p1._x, p1._y + 1);
                    return p2;
                }
                else
                {
                    Point p2 = new Point(p1._x, p1._y);
                    return p2;
                }
            }
        }

        public Point DeterminateNeighbourX(Point p1, EHorizentalOrientation v)
        {
            if (v == EHorizentalOrientation.TO_THE_LEFT)
            {
                Point p2 = new Point(p1._x - 1, p1._y);
                return p2;
            }
            else
            {
                if (v == EHorizentalOrientation.TO_THE_RIGHT)
                {
                    Point p2 = new Point(p1._x + 1, p1._y);
                    return p2;
                }
                else
                {
                    Point p2 = new Point(p1._x, p1._y);
                    return p2;
                }
            }
        }
    }
}