using System;

namespace Algodat {
    class Program {
        static void Main(string[] args)
        {
            Console.Beep();

            /*Console.WriteLine(Algorithm.F(5));
            Console.WriteLine(Algorithm.P(2, 3));
            Console.WriteLine(Algorithm.AddRec(4, 7));
            Console.WriteLine(Algorithm.Fibonacci(5));
            Console.WriteLine(Algorithm.GGT(8,4));
            Console.WriteLine(Algorithm.Modulo(58,16));*/
            int[] list = new[] {3, 24, 64, 74};
            Console.WriteLine(Algorithm.BinarySearch(list, 64, 0, list.Length - 1));
        }
    }
}