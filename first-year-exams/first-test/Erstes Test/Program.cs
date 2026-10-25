using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintShape(10);

            Console.ReadKey();
        }

        static void PrintShape(int x)
        {
            int a = x;
            int b = 1;
            int tempB = b;
            int c = x - 1;
            int tempC = c;
            int d = 1;
            int tempD = d;

            while (a >= 1)
            {
                while (b >= 1)
                {
                    Console.Write("*");
                    --b;
                }
                ++tempB;
                b = tempB;

                while (c >= 1)
                {
                    Console.Write(" ");
                    --c;
                }
                --tempC;
                c = tempC;

                while (d >= 1)
                {
                    Console.Write("*");
                    --d;
                }
                ++tempD;
                d = tempD;

                Console.WriteLine();
                --a;
            }
        }
    }
}