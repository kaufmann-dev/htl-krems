using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] max = new int[7];
            max[0] = 66;
            max[1] = 25;
            max[2] = 42;
            max[3] = 11;
            max[4] = 82;
            max[5] = 356;
            max[6] = 222;

            int[] thomas = InverseList(max);

            //PrintList(thomas);

            int[] christian = CalculateMinMax(thomas);


            Console.WriteLine("Erster Wert ist Minimum von Thomas  │");
            Console.WriteLine("Zweiter Wert ist Maximum von Thomas │");
            Console.WriteLine("────────────────────────────────────┘");
            PrintList(christian);

            Console.ReadLine();
        }

        //CalculateMinMax
        //Rückgabewert: int[] florian
        //Eingabewert: int[] tobias
        //Aufgabe: Tobias durchsuchen und kleinstes und größtes Element finden
        static int[] CalculateMinMax(int[] tobias)
        {
            int[] florian = new int[2];
            florian[0] = tobias[0];
            florian[1] = tobias[0];

            for (int i = 0; i < tobias.Length; i++)
            {
                if (florian[0] > tobias[i])
                {
                    florian[0] = tobias[i];
                }
            }

            for (int i = 0; i < tobias.Length; i++)
            {
                if (florian[1] < tobias[i])
                {
                    florian[1] = tobias[i];
                }
            }

            return florian;
        }

        //Printlist
        //Eingabewert: int[] david
        static void PrintList(int[] david)
        {
            for (int i = 0; i < david.Length; i++)
            {
                Console.WriteLine(david[i]);
            }
        }

        //InverseList
        //Eingabewert: int[] marccel
        //Rückgabewert: int[] johanna
        //Aufgabe: Letztes Marcel Element wird bei Johanna das Erste, Erstes Marcel Element wird bei Johanna Letztes
        static int[] InverseList(int[] marcel)
        {
            int[] johanna = new int[marcel.Length];

            for (int i = 0, laurenz = marcel.Length - 1; i < marcel.Length; i++, laurenz--)
            {
                johanna[i] = marcel[laurenz];
            }

            return johanna;
        }
    }
}
