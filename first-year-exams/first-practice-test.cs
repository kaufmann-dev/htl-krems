//David Kaufmann
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        //f 0 ist maximum
        //f 1 ist minimum
        static void Main(string[] args)
        {
            int[] hugo = CalculateList();
            int[] f = CalculateMinMax(hugo);

            Console.WriteLine("Das Minimum ist " + f[0]);
            Console.WriteLine("Das Maximum ist " + f[1]);

            Console.ReadLine();
        }

        //Liste generieren mit Zahlen, keinen Eingabeparameter
        //Erray mit 100 Elementen
        //Element 1 = 100, Element 2 = 99, ..., Element 100 = 1
        static int[] CalculateList()
        {
            int[] original = new int[100];

            for (int i = 0, zahl = 100; i < original.Length; i++, zahl--)
            {
                original[i] = zahl;
            }

            return original;
        }

        //Maximum und Minimum von CalculateList
        //Eingabe: int erray
        static int[] CalculateMinMax(int[] liste)
        {
            int[] f = new int[2];
            f[0] = liste[0];
            f[1] = liste[0];
            
            for (int i = 1; i < liste.Length; i++)
            {
                if(f[0] < liste[i])
                {
                    f[0] = liste[i];
                }
                if (f[1] < liste[i])
                {
                    f[1] = liste[i];
                }
            }

            return f;
        }
    }
}
