using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list1 = new int[8];
            list1[0] = 1;
            list1[1] = 4;
            list1[2] = 8;
            list1[3] = 24;
            list1[4] = 567;
            list1[5] = 7;
            list1[6] = 2342;
            list1[7] = 99;
            int a = Min(list1);
            Console.WriteLine(a);

            Console.WriteLine("---");

            int[] list2 = new int[5];
            list2[0] = 3;
            list2[1] = 3;
            list2[2] = 3;
            list2[3] = 2;
            list2[4] = 4;
            int[] list3 = RemoveElement(list2, 2);
            PrintList(list3);

            Console.WriteLine("---");

            int[] list4 = new int[5];
            list4[0] = 4;
            list4[1] = 4;
            list4[2] = 6;
            list4[3] = 6;
            list4[4] = 3;
            int b = CountDistinct(list4);
            Console.WriteLine(b);

            Console.WriteLine("---");

            int[] list5 = new int[5];
            list5[0] = 4;
            list5[1] = 4;
            list5[2] = 6;
            list5[3] = 6;
            list5[4] = 3;
            int c = CountMultiples(list5, 4);
            Console.WriteLine(c);

            Console.WriteLine("---");

            int[] list6 = new int[5];
            list6[0] = 4;
            list6[1] = 4;
            list6[2] = 6;
            list6[3] = 6;
            list6[4] = 3;
            int[] list7 = FindDistinct(list6);
            PrintList(list7);

            Console.ReadKey();
        }

        public static void PrintList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        public static int Min(int[] list)
        {
            int min = list[0];

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] < min)
                {
                    min = list[i];
                }
            }

            return min;
        }

        public static int[] RemoveElement(int[] list, int element)
        {
             int count = 0;
             for (int i = 0; i < list.Length; i++)
             {
                 if (list[i] != element)
                 {
                     count++;
                 }
             }

             int[] finalList = new int[count];
             for (int i = 0, j = 0; i < list.Length; i++)
             {
                if (list[i] != element)
                {
                    finalList[j] = list[i];
                    j++;
                }
             }

            return finalList;
        }

        public static int CountDistinct(int[] list)
        {
            int number = 0;

            int[] newList = new int[list.Length];

            for (int i = 0, j = 0; i < list.Length; i++)
            {
                number = list[i];
                bool alreadyThere = SearchList(newList, number);
                if(alreadyThere == false)
                {
                    newList[j] = number;
                    j++;
                }
            }

            int count = 0;
            for (int i = 0; i < newList.Length; i++)
            {
                if (newList[i] != 0)
                {
                    count++;
                }
            }

            return count;
        }

        public static bool SearchList(int[] list, int x)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == x)
                {
                    return true;
                }
            }

            return false;
        }

        public static int CountMultiples(int[] list, int value)
        {
            int count = 0;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == value)
                {
                    count++;
                }
            }

            return count;
        }

        public static int[] FindDistinct(int[] list)
        {
            int number = 0;
            int[] newList = new int[list.Length];

            for (int i = 0, j = 0; i < list.Length; i++)
            {
                number = list[i];
                bool alreadyThere = SearchList(newList, number);
                if (alreadyThere == false)
                {
                    newList[j] = number;
                    j++;
                }
            }

            int count = 0;
            for (int i = 0; i < newList.Length; i++)
            {
                if (newList[i] != 0)
                {
                    count++;
                }
            }

            int[] finalList = new int[count];
            for (int i = 0; i < finalList.Length; i++)
            {
                finalList[i] = newList[i];
            }

            return finalList;
        }
    }
}
