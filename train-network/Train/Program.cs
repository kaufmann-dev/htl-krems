using System;

namespace Train {
    class Program {
        static void Main(string[] args)
        {
            Console.Beep();
            
            Landscape l = new Landscape();
            l.DisplayField();
            
            Point p1 = new Point(3, 1);
            Point p2 = new Point(1, 3);
            p1.CalculateRoute(p2);
        }
    }
}