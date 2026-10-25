using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEDTneu
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Loop();
            PrintTriangle1(7);
            PrintTriangle2(7);
            Loop2();
            Unterschiede();

            int[] list = new int[100];
            list[0] = 5;
            list[1] = 18;
            list[2] = 23;
            list[3] = 45;
            PrintList(list);

            int[] list = CalculateNumberList(100);
            PrintList(list);

            int[] list = CalculateSquareList(6);
            PrintList2(list);

            int[] list = Verkehrtlololo(5);
            PrintList(list);
            
            int[] list = NumberListOdd(25);
            PrintList(list);

            int[] list = new int[10];
            list[0] = 45;
            list[1] = 189;
            list[2] = 199;
            list[3] = 86;
            list[4] = 11;
            list[5] = -1;
            list[6] = 2;
            list[7] = 220;
            list[8] = 35;
            list[9] = 12;
            int max = CalculateMax(list);
            Console.WriteLine(max);

            int[] minliste = new int[10];
            minliste[0] = 45;
            minliste[1] = 189;
            minliste[2] = 199;
            minliste[3] = 86;
            minliste[4] = 11;
            minliste[5] = -1;
            minliste[6] = 2;
            minliste[7] = 220;
            minliste[8] = 35;
            minliste[9] = 12;
            int min = CalculateMin(minliste);
            Console.WriteLine(min);

            char[] palindrom = new char[4];
            palindrom[0] = 'a';
            palindrom[1] = 'n';
            palindrom[2] = 'n';
            palindrom[3] = 'a';
            bool a = IsPalindrom(palindrom);
            Console.WriteLine(a);

            CalculateList();
            int[] david = CalculateList();
            PrintList(david);

            int[] triangle = new int[3];
            triangle[0] = 15;
            triangle[1] = 10;
            triangle[2] = 7;
            bool isPerpendicular = IsPerpendicularTriangle(triangle);
            Console.WriteLine("isperpendicular: " + isPerpendicular);

            int[] old = new int[5];
            old[0] = 23;
            old[1] = 13;
            old[2] = 24;
            old[3] = 5;
            old[4] = 37;
            int[] neu = CopyList(old);
            PrintList(neu);

            int[] list1 = new int[5];
            list1[0] = 12;
            list1[1] = 42;
            list1[2] = 3;
            list1[3] = 8;
            list1[4] = 645;
            int[] list2 = new int[2];
            list2[0] = 32;
            list2[0] = 15;
            int[] neu = MergeLists(list1, list2);
            PrintList(neu);

            int[] lista = new int[2];
            lista[0] = 4;
            lista[1] = 5;
            int[] listb = new int[2];
            listb[0] = 8;
            listb[1] = 2;
            int[] listc = new int[2];
            listc[0] = 99;
            listc[1] = 105;
            int[] listd = new int[2];
            listd[0] = 43;
            listd[1] = 54;
            int[] neu = MergeMultipleLists(lista, listb, listc, listd);
            PrintList(neu);
            
            int size = 20;
            int n = 999;
            PrintListReport(size, n);*/

            int n = 7;
            int[] list = CalculateFibanocci(n);
            PrintList(list);

            Console.ReadLine();
        }

        static int[] CalculateFibanocci(int n)
        {
            int[] list = new int[n];
            list[0] = 1;
            list[1] = 1;

            for (int i = 2; i < list.Length; i++)
            {
                list[i] = list[i - 1] + list[i - 2];
            }

            return list;
        }

        //Generieren Sie eine Liste mit Zufallszahlen der Länger size
        //Die Zufallszahlen liegen zwischen 0 und n
        //Berechnen Sie das maximale Element der Liste
        //Geben Sie es aus
        //Berechnen sie das minimale Element der Liste
        //Geben Sie es aus
        static void PrintListReport(int size, int n)
        {
            int[] liste = GenerateRandomNumberList(size, n);

            int max = CalculateMax(liste);
            Console.WriteLine("max: " + max);

            int min = CalculateMin(liste);
            Console.WriteLine("min: " + min);

            CalculateMin(liste);
        }

        static int[] GenerateRandomNumberList(int size, int n)
        {
            Random r = new Random();

            int[] list = new int[size];

            for (int i = 0; i < size; i++)
            {
                list[i] = r.Next(n);
            }

            return list;
        }

        static int[] MergeMultipleLists(int[] lista, int[] listb, int[] listc, int[] listd)
        {
            int[] list1 = MergeLists(lista, listb);
            int[] list2 = MergeLists(listc, listd);
            int[] neu = MergeLists(list1, list2);

            return neu;
        }

        static int[] MergeLists(int[] list1, int[] list2)
        {
            int[] neu = new int[list1.Length + list2.Length];

            for (int i = 0; i < list1.Length; i++)
            {
                neu[i] = list1[i];
            }

            for (int i = 0; i < list2.Length; i++)
            {
                neu[i + list1.Length] = list2[i];
            }

            return neu;
        }

        static int[] CopyList(int[] old)
        {
            int[] neu = new int[old.Length];

            for (int i = 0; i < old.Length; i++)
            {
                neu[i] = old[i];
            }

            return neu;
        }

        static int[] CalculateList()
        {
            int[] list = new int[100];

            for (int i = 0, j = 100; i < list.Length; j--, i++)
            {
                list[i] = j;
            }

            return list;
        }

        static bool IsPerpendicularTriangle(int[] triangle)
        {
            int a = triangle[0];
            int b = triangle[1];
            int c = triangle[2];

            if (a * a + b * b == c * c)
            {
                return true;
            }

            if (b * b + c * c == a * a)
            {
                return true;
            }

            if (a * a + c * c == b * b)
            {
                return true;
            }

            return false;
        }

        static bool IsPalindrom(char[] u)
        {
            for (int i = 0, j = u.Length; i == j; i++, j--)
            {
                if (u[i] != u[j - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static int CalculateMin(int[] list)
        {
            int min = list[0];

            for (int i = 1; i < list.Length; i++)
            {
                if (min > list[i])
                {
                    min = list[i];
                }
            }

            return min;
        }

        static int CalculateMax(int[] list)
        {
            int max = list[0];

            for (int i = 1; i < list.Length; i++)
            {
                if (max < list[i])
                {
                    max = list[i];
                }
            }

            return max;
        }

        static int[] Verkehrtlololo(int z)
        {
            int[] list = new int[z];

            for (int g = z, i = 1; g > 0; --g, ++i)
            {
                list[g - 1] = i;
            }

            return list;
        }

        static int[] NumberListOdd(int n)
        {
            int[] list = null;

            if (n % 2 == 1)
            {
                list = new int[n / 2 + 1];
            }
            else
            {
                list = new int[n / 2];
            }

            for (int i = 0, j = 0; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    list[j] = i;
                    ++j;
                }
            }

            return list;
        }

        static int[] CalculateSquareList(int n)
        {
            ++n;

            int[] list = new int[n];

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = i * i;
            }

            return list;
        }

        static int[] CalculateNumberList(int n)
        {
            int[] list = new int[n];

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = i + 1;
            }

            return list;
        }

        static void PrintList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void PrintList2(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void Unterschiede()
        {
            int k = 5;
            int z = 10;

            k = k++ * k++;//32
            z = k++ * ++k;//960

            Console.WriteLine(k);
            Console.WriteLine(z);
        }

        static void Loop2()
        {
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(i);
            }
        }

        /*static void PrintTriangle2(int n)
        {
            for (int h = n; h > 0; --h)
            {
                for (int b = n - 1; b > 0; --b)
                {
                    Console.Write("_");
                }

                for (int o = n; n < 0; ++1)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }*/

        static void Loop()
        {
            for (int i = 10; i > 0; --i)
            {
                Console.WriteLine("Hi!");
                --i;
            }
        }

        static void PrintTriangle1(int n)
        {
            for (int j = 0, tempN = n; j < n; j++, --tempN)
            {
                for (int i = tempN; i > 0; --i)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}

/*
              +
            +++
          +++++
*/
