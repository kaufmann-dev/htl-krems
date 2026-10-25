using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadKey();
        }

        public static int[,] GenerateField(int x, int y)
        {
            int[,] field = new int[x, y];

            return field;
        }

        public static void PrintField(int[,] field)
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    Console.Write(field[j, i]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsLegal (int[,] field, int x, int y)
        {
            if (y >= 0 && y <= field.GetLength(1) && x >= 0 && x <= field.GetLength(0))
            {
                return true;
            }

            return false;
        }

        public static Point CreatePoint(int x, int y)
        {
            Point p = new Point();

            p.x = x;
            p.y = y;

            return p;
        }
    }
}
