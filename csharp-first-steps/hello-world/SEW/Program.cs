using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sew
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! ║");
            Console.WriteLine("═════════════╝");

            int min = getMinimum(45, 14, 26);
            Console.WriteLine("==================");
            Console.WriteLine("Minimum von 3 Zahlen");
            Console.WriteLine("------------------");
            Console.WriteLine(min);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int median = getMedian(45, 14, 26);
            Console.WriteLine("==================");
            Console.WriteLine("Median von 3 Zahlen");
            Console.WriteLine("------------------");
            Console.WriteLine(median);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int max = calculateMax(45, 14, 26);
            Console.WriteLine("==================");
            Console.WriteLine("Maximum von 3 Zahlen");
            Console.WriteLine("------------------");
            Console.WriteLine(max);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("==================");
            Swap(4, 10);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            double usage = CalcPatrolUsage(1, 20);
            Console.WriteLine("==================");
            Console.WriteLine("Benzinverbrauch");
            Console.WriteLine("------------------");
            Console.WriteLine(usage);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            double euro = convertToEuro(20);
            Console.WriteLine("==================");
            Console.WriteLine("Schilling zu Euro");
            Console.WriteLine("------------------");
            Console.WriteLine(euro);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int signum = calculateSignum(-101);
            Console.WriteLine("==================");
            Console.WriteLine("Signum");
            Console.WriteLine("------------------");
            Console.WriteLine(signum);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            bool Triangle = isTriangle(5, 9, 8);
            Console.WriteLine("==================");
            Console.WriteLine("Ergeben Werte Dreieck?");
            Console.WriteLine("------------------");
            Console.WriteLine(Triangle);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int Betrag = BetragoBerechnen(-10);
            Console.WriteLine("==================");
            Console.WriteLine("Betrago berechnen");
            Console.WriteLine("------------------");
            Console.WriteLine(Betrago);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            bool gleichseitig = isEquilateralTriangle(10, 10, 10);
            Console.WriteLine("==================");
            Console.WriteLine("Ist Dreieck gleichseitig?");
            Console.WriteLine("------------------");
            Console.WriteLine(gleichseitig);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            bool RightAngled = isRightAngledTriangle(4, 3, 5);
            Console.WriteLine("==================");
            Console.WriteLine("Ist Dreieck rechtwinklig?");
            Console.WriteLine("------------------");
            Console.WriteLine("RightAngled:" + RightAngled);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int value = calculateIdentity(10);
            Console.WriteLine("==================");
            Console.WriteLine("identität");
            Console.WriteLine("------------------");
            Console.WriteLine(value);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int result = calculateFaktorielle(5);
            Console.WriteLine("==================");
            Console.WriteLine("Faktorielle");
            Console.WriteLine("------------------");
            Console.WriteLine(result);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int mult = calculatemult(4, 3);
            Console.WriteLine("==================");
            Console.WriteLine("Multiplikation");
            Console.WriteLine("------------------");
            Console.WriteLine(mult);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            int d = StellenEinerZahlBerechnen(1043);
            Console.WriteLine("==================");
            Console.WriteLine("Stellen der Zahl");
            Console.WriteLine("------------------");
            Console.WriteLine(d);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("==================");
            Console.WriteLine("Rechteck ausgeben");
            Console.WriteLine("------------------");
            printRectangle(4, 6);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("==================");
            Console.WriteLine("Secret 7");
            Console.WriteLine("------------------");
            int sec = secret7(10, 5);
            Console.WriteLine(sec);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("==================");
            Console.WriteLine("Dreieck 1 ausgeben");
            Console.WriteLine("------------------");
            printTriangle1(8);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("==================");
            Console.WriteLine("Dreieck 2 ausgeben");
            Console.WriteLine("------------------");
            printTriangle2(8);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("==================");
            Console.WriteLine("Dreieck 3 ausgeben");
            Console.WriteLine("------------------");
            printTriangle3(8);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine();

           Console.WriteLine("==================");
           Console.WriteLine("Dreieck 4 ausgeben");
           Console.WriteLine("------------------");
           printTriangle4(8);
           Console.WriteLine("==================");
           Console.WriteLine();
           Console.WriteLine();

           Console.WriteLine("==================");
           Console.WriteLine("Form ausgeben");
           Console.WriteLine("------------------");
           printShape(8);
           Console.WriteLine("==================");
           Console.WriteLine();
           Console.WriteLine();

           Console.WriteLine("==================");
           Console.WriteLine("Type Test");
           Console.WriteLine("------------------");
           TypeTest();
           Console.WriteLine("==================");
           Console.WriteLine();
           Console.WriteLine();

           Console.WriteLine("==================");
           Console.WriteLine("Type Test 2");
           Console.WriteLine("------------------");
           TypeTest2();
           Console.WriteLine("==================");
           Console.WriteLine();
           Console.WriteLine();

           Console.WriteLine("==================");
           Console.WriteLine("Type Test 3");
           Console.WriteLine("------------------");
           TypeTest3();
           Console.WriteLine("==================");
           Console.WriteLine();
           Console.WriteLine();

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("Werte vertauschen // selbst programiert");
           WerteVertauschen(4, 6);
           Console.WriteLine("------------------------------------------------------------");

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("Benzinverbrauch berechnen // selbst programiert");
           Benzinverbrauch(10, 50);
           Console.WriteLine("------------------------------------------------------------");

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("Euro in Schilling umrechnen // selbst programiert");
           EuroZuSchilling(10);
           Console.WriteLine("------------------------------------------------------------");

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("BMI berechnen // selbst programiert");
           BMIberechnen(80.5f, 1.8f);
           Console.WriteLine("------------------------------------------------------------");

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("Maximum 3er Zahlen berechnen // selbst programiert");
           Maximum3erZahlen(10, 55, 9);
           Console.WriteLine("------------------------------------------------------------");

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("Betrag einer Zahl berechnen // selbst programiert");
           BetragBerechnen(-56);
           Console.WriteLine("------------------------------------------------------------");

           Console.WriteLine("------------------------------------------------------------");
           Console.WriteLine("-1, 1 oder 0 // selbst programiert");
           DreiZustände(600);
           Console.WriteLine("------------------------------------------------------------");



            Console.ReadLine();
        }

        static void DreiZustände(int zahl)
        {
            Console.WriteLine("Wenn Ihre Zahl kleiner als 0 ist befindet sie sich im Zustand -1");
            Console.WriteLine("Wenn Ihre Zahl größer als 0 ist befindet sie sich im Zustand 1");
            Console.WriteLine("Wenn Ihre Zahl 0 ist befindet sie sich im Zustand 0");
            Console.ReadKey();
            Console.WriteLine("Ihre Zahl beträgt " + zahl);
            Console.ReadKey();

            if (zahl < 0)
            {
                Console.WriteLine("Zustand: -1");
            }
            else
            {
                if (zahl > 0)
                {
                    Console.WriteLine("Zustand: 1");
                }
                else
                {
                    Console.WriteLine("Zustand: 0");
                }
            }
        }

        static void BetragoBerechnen(int zahl)
        {
            Console.WriteLine("Ihre Zahl ist " + zahl);
            Console.ReadKey();

            if (zahl >= 0)
            {
                Console.WriteLine("Der Betrag ihrer Zahl beträgt " + zahl);
            }
            else
            {
                int betrag = zahl * -1;
                Console.WriteLine("Der Betrag ihrer Zahl beträgt " + betrag);
            }
        }

        static void Maximum3erZahlen(int a, int b, int c)
        {
            Console.WriteLine("Ihre Zahlen haben die Werte " + a + ", " + b + " und " + c);
            Console.ReadKey();

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine("Die größte Zahl beträgt den Wert " + a);
                }
                else
                {
                    Console.WriteLine("Die größte Zahl beträgt den Wert " + c);
                }
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine("Die größte Zahl beträgt den Wert " + b);
                }
                else
                {
                    Console.WriteLine("Die größte Zahl beträgt den Wert " + c);
                }
            }
        }

        static void BMIberechnen(float kg, float m)
        {
            Console.WriteLine("Sie wiegen " + kg + " Kilogramm und Sie sind " + m + " Meter hoch");
            Console.ReadKey();

            float bmi = kg / (m * m);

            Console.WriteLine("Ihr BMI beträgt " + bmi);
        }

        static void EuroZuSchilling(int euro)
        {
            Console.WriteLine("Wir haben " + euro + " Euro");
            Console.ReadKey();

            float schilling = euro * 13.76f;

            Console.WriteLine("Das sind " + schilling + " Schilling");
        }

        static void WerteVertauschen(int a, int b)
        {


            Console.WriteLine("A ist " + a + " und B ist " + b);
            Console.ReadKey();

            int c = a;
            b = a;
            a = c;

            Console.WriteLine("A ist jetzt " + a + " und B ist jetzt " + b);
        }

        static void Benzinverbrauch(int km, int l)
        {
            Console.WriteLine("Wir fahren " + km + " Kilometer mit " + l + " Liter");
            Console.ReadKey();

            int usage = l / km * 100;

            Console.WriteLine("Unser Benzinverbrauch beträgt " + usage);
        }

        static void TypeTest3()
        {
            int a = 300;
            int b = 10000;
            float c = 0.1f;
            float d = 0.34235f;

            float a1 = 3E2f;
            float b1 = 1E4f;
            float c1 = 1e-1f;
            float d1 = 34225e-6f;

            Console.WriteLine("solution d1: " + d1);
        }

        static void TypeTest2()
        {
            double a = 345.45;
            float b = 435.45f;
            long c = 4000;
            int d = 35;

            double x1 = a + b;
            float x3 = b + d;
            long x5 = c + d;

            Console.WriteLine("solution x5: " + x5);
        }

        static void TypeTest()
        {
            long a = 40000;
            int b = 20;
            short c = 5;
            byte d = 3;

            int x1 = b + c;
            long x3 = a + b + c;
            long x4 = a * c;

            long x5 = a / c;
            long x6 = a * c / b;
            int x7 = b / d;

            Console.WriteLine("solution x7: " + x7);
        }

        static void Swap(int x, int y)//Werte von 2 Variablen vertauschen
        {

            int z;

            z = y;
            y = x;
            x = z;

            Console.WriteLine("Werte vertauschen");
            Console.WriteLine("------------------");
            Console.WriteLine("x:" + x);
            Console.WriteLine("y:" + y);

        }

        static void printTriangle1(int x)//Rechtwinkliges Dreieck zeichnen
        {
            int line = 1;

            while (x > 0)
            {
                int tmpLine = line;

                while (line > 0)
                {
                    Console.Write("*");
                    line = line - 1;
                }

                line = tmpLine;
                line = line + 1;
                Console.WriteLine();

                x = x - 1;
            }
        }

        static double CalcPatrolUsage(int km, int l)//Benzinverbrauch in Liter pro 100 Kilometer berechnen
        {
            double usage = l / km * 100;



            return usage;
        }

        static double convertToEuro(double schilling)//Schilling in Euro umrechnen
        {
            double euro = schilling / 13.76;

            return euro;

        }

        static int calculateMax(int a, int b, int c)//Maximale von 3 Zahlen berechnen
        {
            int max = 0;

            if (a > b)
            {
                if (a > c)
                {
                    max = a;
                }
                else
                {
                    max = c;
                }
            }
            else
            {
                if (b > c)
                {
                    max = b;
                }
                else
                {
                    max = c;
                }
            }

            return max;
        }

        static int getMinimum(int a, int b, int c)//Minimum von 3 Zahlen berechnen
        {
            int min = 0;

            if (a < b)
            {
                if (a < c)
                {
                    min = a;
                }
                else
                {
                    min = c;
                }
            }
            else
            {
                if (c > b)
                {
                    min = c;
                }
                else
                {
                    min = b;
                }
            }
            return min;

        }

        static int getMedian(int x, int y, int z)//Median von 3 Zahlen berechnen
        {
            int median = 0;

            if (x > y)
            {
                if (y > z)
                {
                    median = y;
                }
                else
                {
                    if (x > z)
                    {
                        median = z;
                    }
                    else
                    {
                        median = x;
                    }
                }
            }
            else
            {
                if (x > z)
                {
                    median = x;
                }
                else
                {
                    if (y > z)
                    {
                        median = z;
                    }
                    else
                    {
                        median = y;
                    }
                }
            }
            return median;

        }

        static int calculateSignum(int x)//Überprüfen, ob negative Zahl oder positive Zahl ausgegeben werden muss("Signum Funktion")
        {
            int signum = 0;

            if (x < 0)
            {
                signum = -1;
            }
            else
            {
                if (x > 0)
                {
                    signum = 1;
                }
                else
                {
                    signum = 0;
                }
            }

            return signum;

        }

        static bool isTriangle(int x, int y, int z)//Überprüfen, ob ein Dreieck gegeben ist
        {
            bool Triangle = true;

            if (y > x + z)
            {
                Triangle = false;
            }
            else
            {
                if (x > y + z)
                {
                    Triangle = false;
                }
                else
                {
                    if (z > x + y)
                    {
                        Triangle = false;
                    }
                    else
                    {
                        Triangle = true;
                    }
                }
            }

            return Triangle;
        }

        static int BetragBerechnen(int x)//Betrag einer Zahl berechnen
        {
            int Betrag = 0;

            if (x < 0)
            {
                x = x * -1;
                Betrag = x;
            }
            else
            {
                Betrag = x;
            }

            return Betrag;
        }

        static bool isEquilateralTriangle(int x, int y, int z)//Überprüfen, ob ein gleichseitiges Dreieck gegeben ist
        {
            bool gleichseitig = true;


            if (x == y)
            {
                if (y == z)
                {
                    gleichseitig = true;
                }
                else
                {
                    gleichseitig = false;
                }
            }
            else
            {
                gleichseitig = false;
            }
            return gleichseitig;
        }

        static bool isRightAngledTriangle(int x, int y, int z)//Überprüfen, ob ein rechtwinkeliges Dreieck gegeben ist
        {
            bool RightAngled = true;

            if ((x * x) + (y * y) == (z * z))
            {
                RightAngled = true;
            }
            else
            {
                if ((x * x) + (z * z) == (y * y))
                {
                    RightAngled = true;
                }
                else
                {
                    if ((y * y) + (z * z) == (x * x))
                    {
                        RightAngled = true;
                    }
                    else
                    {
                        RightAngled = false;
                    }
                }
            }


            return RightAngled;
        }

        static int calculateIdentity(int x)//Berechnet den Eingabewert nochmal(Quasi die Identität von der Zahl, deswegen "calculateIdentity")
        {
            int value = 0;

            while (x > 0)
            {
                value = value + 1;
                x = x - 1;
            }



            return value;
        }

        static int calculateFaktorielle(int x)//Berechnet Faktorielle(z.B.: 5!=5*4*3*2*1)
        {
            int result = 1;

            while (x > 1)
            {
                result = result * x;
                x = x - 1;
            }


            return result;
        }

        static int calculatemult(int a, int b)//Zwei Zahlen miteinander multiplizieren, ohne wirklich zu multiplizieren
        {
            int mult = 0;

            while (b > 0)
            {
                mult = mult + a;
                b = b - 1;
            }




            return mult;
        }

        static int StellenEinerZahlBerechnen(int n)//Berechnet, wie viele Stellen eine Zahl hat
        {
            int d = 1;

            while (n > 9)
            {
                n = n / 10;
                d = d + 1;
            }

            return d;
        }

        static void printRectangle(int x, int y)//Rechteck zeichnen
        {
            int a = y;

            while (x > 0)
            {
                while (y > 0)
                {
                    Console.Write("*");
                    y = y - 1;
                }
                y = a;
                Console.WriteLine();
                x = x - 1;
            }


        }

        static int secret7(int x, int y)//Secret 7 ausrechnen
        {
            int z = 0;

            while (x > 0)
            {
                if (x % 2 == 1)
                {
                    z = z + y;
                    x = x - 1;
                }
                else
                {
                    y = 2 * y;
                    x = x / 2;
                }
            }

            return z;
        }

        static void printTriangleReverted(int x)//Rechtwinkliges Dreieck seitenverkehrt
        {

        }

        static void printTriangle3(int x)
        {
            int a = x;

            while (x > 0)
            {
                while (a > 0)
                {
                    Console.Write("*");
                    a = a - 1;
                }

                Console.WriteLine();
                x = x - 1;
                a = x;
            }
        }

        static void printTriangle2(int x)
        {
            int a = x, b = 1, c = 1;

            while (x > 0)
            {
                while (b > 1)
                {
                    Console.Write(" ");
                    b = b - 1;
                }
                if (a % 2 == 1)
                {
                    while (a > 0)
                    {
                        Console.Write("+");
                        a = a - 1;
                    }
                }
                else
                {
                    while (a > 0)
                    {
                        Console.Write("*");
                        a = a - 1;
                    }
                }

                x = x - 1;
                a = x;
                b = c + 1;
                c = b;
                Console.WriteLine();
            }
        }

        static void printTriangle4(int a)
        {
            int u = 0;
            int tmp_u = u;
            int s = a;
            int tmp_s = s;


            while (a > 0)
            {
                while (u > 0)
                {
                    Console.Write("_");
                    --u;
                }

                while (s > 0)
                {
                    Console.Write("*");
                    --s;
                }

                ++tmp_u;
                u = tmp_u;

                --tmp_s;
                s = tmp_s;

                Console.WriteLine();
                --a;
            }


        }

        static void printShape(int n)
        {
            int i = 0;
            int tmp_i = i;
            int j = n;
            int tmp_j = j;

            while (n > 0)
            {
                while (i > 0)
                {
                    Console.WriteLine(" ");
                    --i;
                }
                while (j > 0)
                {
                    Console.Write("**");
                    --j;
                }
                ++tmp_i;
                i = tmp_i;

                --tmp_j;
                j = tmp_j;

                --n;
                Console.WriteLine();
            }
        }
    }
}