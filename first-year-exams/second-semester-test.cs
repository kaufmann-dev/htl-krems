using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] jonas = new int[12];
            jonas[0] = 11;
            jonas[1] = 43;
            jonas[2] = 57;
            jonas[3] = 346;
            jonas[4] = 4;
            jonas[5] = 80;
            jonas[6] = 5;
            jonas[7] = 745;
            jonas[8] = 56;
            jonas[9] = 92;
            jonas[10] = 32;
            jonas[11] = 48;

            int split = 7;

            int[] johanna = ManipulateList(jonas, split);

            PrintList(johanna);

            Console.ReadLine();
        }

        static void PrintList(int[] yung)
        {
            for (int i = 0; i < yung.Length; i++)
            {
                Console.WriteLine(yung[i]);
            }
        }

        static int[] SplitList(int[] sad, int split)
        {
            int[] eins220 = new int[split - 1];

            for (int i = 0; i < split - 1; i++)
            {
                eins220[i] = sad[i];
            }

            return eins220;
        }

        static int[] ReverseList(int[] schasso)
        {
            int help = 0;

            for (int i = 0, j = schasso.Length - 1; i < j; i++, j--)
            {
                help = schasso[i];
                schasso[i] = schasso[j];
                schasso[j] = help;
            }

            return schasso;
        }

        static int[] ManipulateList(int[] norbert, int split)
        {
            int[] paul = SplitList(norbert, split);
            int[] panhofer = ReverseList(paul);

            return panhofer;
        }
    }
}
