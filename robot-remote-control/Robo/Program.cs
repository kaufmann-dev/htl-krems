using System;

namespace Robo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Point[,] sdas = new Point[3, 3];
            sdas[1, 1] = new Point(3, 2);
            if (sdas[1, 1] == null)
            {
                Console.WriteLine("lol");
            }
            
            Point p1 = new Point(3, 4);
            p1.X = 3;
        }
    }
}