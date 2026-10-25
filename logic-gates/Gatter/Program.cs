
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool wahr = true;
            bool falsch = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                   ║");
            Console.WriteLine("    Logikgatter    ║");
            Console.WriteLine("                   ║");
            Console.WriteLine("═══════════════════╝");
            Console.WriteLine("");

            /*Console.WriteLine(wahr + "\t NOT \t \t \t" + NOT(wahr));
            Console.WriteLine(falsch + "\t NOT \t \t \t" + NOT(falsch) + "\n");

            Console.WriteLine(falsch + "\t OR \t" + falsch + "\t \t" + OR(falsch, falsch));
            Console.WriteLine(wahr + "\t OR \t" + falsch + "\t \t" + OR(wahr, falsch));
            Console.WriteLine(falsch + "\t OR \t" + wahr + "\t \t" + OR(falsch, wahr));
            Console.WriteLine(wahr + "\t OR \t" + wahr + "\t \t" + OR(wahr, wahr) + "\n");

            Console.WriteLine(falsch + "\t AND \t" + falsch + "\t \t" + AND(falsch, falsch));
            Console.WriteLine(wahr + "\t AND \t" + falsch + "\t \t" + AND(wahr, falsch));
            Console.WriteLine(falsch + "\t AND \t" + wahr + "\t \t" + AND(falsch, wahr));
            Console.WriteLine(wahr + "\t AND \t" + wahr + "\t \t" + AND(wahr, wahr) + "\n");

            Console.WriteLine(falsch + "\t XOR \t" + falsch + "\t \t" + XOR(falsch, falsch));
            Console.WriteLine(wahr + "\t XOR \t" + falsch + "\t \t" + XOR(wahr, falsch));
            Console.WriteLine(falsch + "\t XOR \t" + wahr + "\t \t" + XOR(falsch, wahr));
            Console.WriteLine(wahr + "\t XOR \t" + wahr + "\t \t" + XOR(wahr, wahr) + "\n");

            Console.WriteLine(falsch + "\t NOR \t" + falsch + "\t \t" + NOR(falsch, falsch));
            Console.WriteLine(wahr + "\t NOR \t" + falsch + "\t \t" + NOR(wahr, falsch));
            Console.WriteLine(falsch + "\t NOR \t" + wahr + "\t \t" + NOR(falsch, wahr));
            Console.WriteLine(wahr + "\t NOR \t" + wahr + "\t \t" + NOR(wahr, wahr) + "\n");

            Console.WriteLine(falsch + "\t NAND \t" + falsch + "\t \t" + NAND(falsch, falsch));
            Console.WriteLine(wahr + "\t NAND \t" + falsch + "\t \t" + NAND(wahr, falsch));
            Console.WriteLine(falsch + "\t NAND \t" + wahr + "\t \t" + NAND(falsch, wahr));
            Console.WriteLine(wahr + "\t NAND \t" + wahr + "\t \t" + NAND(wahr, wahr) + "\n");

            Console.WriteLine(falsch + "\t XNOR \t" + falsch + "\t \t" + XNOR(falsch, falsch));
            Console.WriteLine(wahr + "\t XNOR \t" + falsch + "\t \t" + XNOR(wahr, falsch));
            Console.WriteLine(falsch + "\t XNOR \t" + wahr + "\t \t" + XNOR(falsch, wahr));
            Console.WriteLine(wahr + "\t XNOR \t" + wahr + "\t \t" + XNOR(wahr, wahr) + "\n");*/

            ShowGatter(falsch, falsch, "OR");
            ShowGatter(wahr, falsch, "OR");
            ShowGatter(falsch, wahr, "OR");
            ShowGatter(wahr, wahr, "OR");
            Console.WriteLine();

            ShowGatter(falsch, falsch, "AND");
            ShowGatter(wahr, falsch, "AND");
            ShowGatter(falsch, wahr, "AND");
            ShowGatter(wahr, wahr, "AND");
            Console.WriteLine();

            ShowGatter(falsch, falsch, "XOR");
            ShowGatter(wahr, falsch, "XOR");
            ShowGatter(falsch, wahr, "XOR");
            ShowGatter(wahr, wahr, "XOR");
            Console.WriteLine();

            ShowGatter(falsch, falsch, "NOR");
            ShowGatter(wahr, falsch, "NOR");
            ShowGatter(falsch, wahr, "NOR");
            ShowGatter(wahr, wahr, "NOR");
            Console.WriteLine();

            ShowGatter(falsch, falsch, "NAND");
            ShowGatter(wahr, falsch, "NAND");
            ShowGatter(falsch, wahr, "NAND");
            ShowGatter(wahr, wahr, "NAND");
            Console.WriteLine();

            ShowGatter(falsch, falsch, "XNOR");
            ShowGatter(wahr, falsch, "XNOR");
            ShowGatter(falsch, wahr, "XNOR");
            ShowGatter(wahr, wahr, "XNOR");

            Console.ReadLine();
        }

        static void ShowGatter(bool a, bool b, string gatter)
        {
            bool ergebnis;
            SetColor(a);
            Console.Write("■");
            SetTextColor();
            Console.Write(" " + gatter + " ");
            SetColor(b);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" --> ");
            ergebnis = GetGatterErgebnis(a, b, gatter);
            SetColor(ergebnis);
            Console.Write("■");
            Console.WriteLine();
        }

        static bool GetGatterErgebnis(bool a, bool b, string s)
        {
            switch (s)
            {
                case "NOT":
                    return NOT(a);

                case "OR":
                    return OR(a, b);

                case "AND":
                    return AND(a, b);

                case "XOR":
                    return XOR(a, b);

                case "NOR":
                    return NOR(a, b);

                case "NAND":
                    return NAND(a, b);

                case "XNOR":
                    return XNOR(a, b);

                default:
                    Console.Write("Falscher Gattername! ");
                    return false;
            }
        }

        static void SetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void SetColor(bool b)
        {
            if (b)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Gray;
        }

        static bool NOT(bool a)
        {
            if(a)
                return false;

            return true;
        }

        static bool OR(bool a, bool b)
        {
            if (a)
                return true;
            else
                if (b)
                    return true;

            return false;
        }

        static bool AND (bool a, bool b)
        {
            if (a)
                if (b)
                    return true;

            return false;
        }

        static bool XOR(bool a, bool b)
        {
            if (a == b)
                return false;

            return true;
        }

        static bool NOR(bool a, bool b)
        {
            return NOT(OR(a, b));
        }

        static bool NAND(bool a, bool b)
        {
            return NOT(AND(a, b));
        }

        static bool XNOR(bool a, bool b)
        {
            return NOT(XOR(a, b));
        }
    }
}