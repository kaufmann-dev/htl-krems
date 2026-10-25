using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[,] field = CreateField(7, 6);

            // TakeTurn(int[,] field, Point p, int player);

            Point zug1 = CreatePoint(3, 6);
            TakeTurn(field, zug1, 1);

            Point zug2 = CreatePoint(2, 6);
            TakeTurn(field, zug2, 2);

            Point zug3 = CreatePoint(3, 5);
            TakeTurn(field, zug3, 1);

            Point zug4 = CreatePoint(2, 5);
            TakeTurn(field, zug4, 2);

            Point zug5 = CreatePoint(3, 4);
            TakeTurn(field, zug5, 1);

            Point zug6 = CreatePoint(2, 4);
            TakeTurn(field, zug6, 2);

            Point zug7 = CreatePoint(3, 3);
            TakeTurn(field, zug7, 1);

            PrintField(field);

            Console.ReadKey();
        }

        public static void Check4(int count, int player)
        {
            if (count == 4)
            {
                EFieldType type = new EFieldType();

                switch (player)
                {
                    case 1:
                        type = EFieldType.PLAYER_RED;
                        break;
                    case 2:
                        type = EFieldType.PLAYER_YELLOW;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("(TESTWIN PLAYER-COUNT ERROR)");
                        break;
                }
            
                switch (type)
                {
                    case EFieldType.PLAYER_RED:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("PLAYER " + player + " HAS WON");
                        break;
                    case EFieldType.PLAYER_YELLOW:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("PLAYER " + player + " HAS WON");
                        break;
                    default:
                        Console.WriteLine("SOMEONE HAS WON");
                        break;
                }
            }
        }

        public static void TestWin (int[,] field, Point p, int player)
        {
            if (p.x + 4 <= field.GetLength(0))
            {
                int countRight = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (field[p.x, p.y] == field[p.x + i, p.y])
                    {
                        countRight++;
                    }
                }
                Check4(countRight, player);
            }

            if(p.x - 4 >= 0)
            {
                int countLeft = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (field[p.x, p.y] == field[p.x - i, p.y])
                    {
                        countLeft++;
                    }
                }
                Check4(countLeft, player);
            }

            if (p.y - 4 >= 0)
            {
                int countUp = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (field[p.x, p.y] == field[p.x, p.y - 1])
                    {
                        countUp++;
                    }
                }
                Check4(countUp, player);
            }

            if (p.y + 4 <= field.GetLength(1))
            {
                int countDown = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (field[p.x, p.y] == field[p.x, p.y + 1])
                    {
                        countDown++;
                    }
                }
                Check4(countDown, player);
            }
        }

        public static int[,] TakeTurn(int[,] field, Point p, int player)
        {
            int error = 9;

            EFieldType type = new EFieldType();

            switch(player)
            {
                case 1:
                    type = EFieldType.PLAYER_RED;
                    break;
                case 2:
                    type = EFieldType.PLAYER_YELLOW;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("(PLAYER-COUNT ERROR)");
                    break;
            }

            if (IsLegal(field, p) == true)
            {
                field[p.x, p.y] = (int)type;
            }
            else
            {
                field[p.x, p.y] = error;
            }

            TestWin(field, p, player);

            return field;
        }

        public static bool IsLegal(int[,] field, Point p)
        {
            if (p.x < 0 || p.y < 0)
            {
                return false;
            }

            if (p.x >= field.GetLength(0) || p.y >= field.GetLength(1))
            {
                return false;
            }

            if(field[p.x, p.y] != (int)EFieldType.DEFAULT)
            {
                return false;
            }

            if(p.y != field.GetLength(1) - 1 && field[p.x, p.y + 1] == (int)EFieldType.DEFAULT)
            {
                return false;
            }

            return true;
        }

        public static Point CreatePoint(int x, int y)
        {
            Point p = new Point();

            p.x = x - 1;
            p.y = y - 1;

            return p;
        }

        public static int[,] CreateField(int x, int y)
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
                    EFieldType type = (EFieldType)field[j, i];
                    switch(type)
                    {
                        case EFieldType.DEFAULT:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(field[j, i]);
                            break;
                        case EFieldType.PLAYER_RED:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(field[j, i]);
                            break;
                        case EFieldType.PLAYER_YELLOW:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(field[j, i]);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("(POSITION ERROR)");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
