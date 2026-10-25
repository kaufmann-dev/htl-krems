using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int dezimalWert;
            string binärString = "";
            int zwischenWert;
            int rest;

            Console.Write("Dezimal: ");

            dezimalWert = Convert.ToInt32(Console.ReadLine());

            zwischenWert = dezimalWert;

            while (zwischenWert > 0)
            {
                rest = zwischenWert % 2;
                if (rest == 0)
                    binärString = "0" + binärString;
                else
                    binärString = "1" + binärString;
                zwischenWert = zwischenWert / 2;
            }
            Console.WriteLine();
            Console.Write("Binär: " + binärString);

            Console.ReadLine();
        }
    }
}