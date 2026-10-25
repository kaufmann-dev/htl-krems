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
            //1
            int hugo = 20;
            int[] oddNumers = GenerateNumberList(hugo);
            PrintList(oddNumers);

                Console.WriteLine("----------");

            //2
            int[] franzi = new int[5];
            franzi[0] = 41;
            franzi[1] = 13;
            franzi[2] = 21;
            franzi[3] = 5;
            franzi[4] = 13;
            int[] josef = new int[3];
            josef[0] = 16;
            josef[1] = 4;
            josef[2] = 99;
            int[] newList = MergeNumberLists(franzi, josef);
            PrintList(newList);

                Console.WriteLine("----------");

            //3
            int[] a = new int[3];
            a[0] = 12;
            a[1] = 32;
            a[2] = 56;
            int[] b = new int[3];
            b[0] = 2359;
            b[1] = 9;
            b[2] = 11;
            int[] c = new int[3];
            c[0] = 25;
            c[1] = 312;
            c[2] = 5;
            int[] d = new int[3];
            d[0] = 23;
            d[1] = 89;
            d[2] = 275;
            int[] merge4 = MergeMoreNumberLists(a, b, c, d);
            PrintList(merge4);

            Console.WriteLine("----------");

            //4
            int[] johanna = new int[3];
            johanna[0] = 2;
            johanna[1] = 1;
            johanna[2] = 9;
            int[] stefan= new int[3];
            stefan[0] = 34;
            stefan[1] = 35;
            stefan[2] = 85;
            int[] max = new int[3];
            max[0] = 894;
            max[1] = 823;
            max[2] = 344;
            int[] florian = GenerateNumberList(hugo);
            int[] final = MergeMoreNumberLists(johanna, stefan, max, florian);
            PrintList(final);

            Console.ReadLine();
        }

        static int[] GenerateNumberList(int hugo)
        {
            int[] oddNumbers = new int [hugo / 2];

            for (int i = 1, a = 0; i < oddNumbers.Length * 2; i++)
            {
                if(i % 2 == 1)
                {
                    oddNumbers[a] = i;
                }
                else
                {
                    a++;
                }
            }

            return oddNumbers;
        }

        static int[] MergeNumberLists(int[] franzi, int[] josef)
        {
            int[] newList = new int [franzi.Length + josef.Length];

            for (int i = 0; i < franzi.Length; i++)
            {
                newList[i] = franzi[i];
            }

            for (int i = 0; i < josef.Length; i++)
            {
                newList[i + franzi.Length] = josef[i];
            }

            return newList;
        }

        static int[] MergeMoreNumberLists(int[] a, int[] b, int[] c, int[] d)
        {
            int[] merge4 = new int[a.Length + b.Length + c.Length + d.Length];

            int[] placeHolder1 = new int[a.Length + b.Length];
            int[] placeHolder2 = new int[c.Length + d.Length];

            placeHolder1 = MergeNumberLists(a, b);
            placeHolder2 = MergeNumberLists(c, d);

            merge4 = MergeNumberLists(placeHolder1, placeHolder2);

            return merge4;
        }

        static void PrintList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
