namespace chessoop
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
            return $"x: {this._x}, y: {this._y}";
        }

        public bool IsEqual(Point p)
        {
            if (this._x == p._x && this._y == p._y)
            {
                return true;
            }

            return false;
        }
    }
}