using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n------------\nBox 1");

            Box box1 = new Box(10, 20, 10);
            Console.WriteLine(box1.Info());

            Console.WriteLine("------------\nBox 2");

            Box box2 = new Box(10, 10, 10);
            Console.WriteLine(box2.Info());

            Console.WriteLine("------------\nBox 3");

            Box box3 = new Box(20, 20, 20);
            Console.WriteLine(box3.Info());

            Console.WriteLine("------------\nRectangle 1");

            Rectangle rectangle1 = new Rectangle(78, 82);
            Console.WriteLine(rectangle1.Info());

            Console.WriteLine("------------\nRectangle 2");

            Rectangle rectangle2 = new Rectangle(42, 42);
            Console.WriteLine(rectangle2.Info());

            Console.WriteLine("------------\nTriangle 1");

            Triangle triangle1 = new Triangle(4, 4, 4);
            Console.WriteLine(triangle1.Info());

            Console.WriteLine("------------\nTriangle 2");

            Triangle triangle2 = new Triangle(5, 12, 13);
            Console.WriteLine(triangle2.Info());

            Console.WriteLine("------------\nTriangle 3");

            Triangle triangle3 = new Triangle(6, 4, 4);
            Console.WriteLine(triangle3.Info());

            Console.ReadKey();
        }
    }
}
