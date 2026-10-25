using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_mit_Z_und_FETT_
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Tower Defense");

            int[,] playfield = CreatePlayfield(15, 15);
            PrintArea(playfield);

            Point[] spawningPools = DiscoverFields(playfield, ETileType.SPAWNING_POOL);
            PrintPointList(spawningPools);

            Console.ReadKey();
        }

        public static void PrintPointList(Point[] points)
        {
            foreach (Point point in points)
            {
                Console.WriteLine("Point: " + point.x + " " + point.y);
            }
        }

        public static void PrintArea(int[,] area)
        {
            for (int i = 0; i < area.GetLength(1); i++)
            {
                for (int j = 0; j < area.GetLength(0); j++)
                {
                    ETileType type = (ETileType)area[j, i];

                    switch (type)
                    {
                        case ETileType.DEFAULT_VALUE:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case ETileType.TOWER:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case ETileType.SPAWNING_POOL:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case ETileType.PLAYER:
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ETileType.MONSTER:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.Write(area[j, i]);
                    Console.ForegroundColor = ConsoleColor.Black;

                }

                Console.WriteLine();
            }
        }

        public static int[,] CreatePlayfield(int x, int y)
        {
            int[,] playfield = new int[x, y];

            for (int i = 0; i < 4; i++)
            {
                SetGeneratedPoint(playfield, ETileType.TOWER);
                SetGeneratedPoint(playfield, ETileType.SPAWNING_POOL);
            }

            return playfield;
        }


        public static Random RANDOM = new Random();

        public static Point CreatePoint(int x, int y)
        {
            Point p = new Point();

            p.x = RANDOM.Next(0, x);
            p.y = RANDOM.Next(0, y);

            return p;
        }

        public static Point GeneratePoint(int[,] playfield)
        {
            int x = playfield.GetLength(0);
            int y = playfield.GetLength(1);

            Point p = CreatePoint(x, y);
            bool isFieldEmpty = IsFieldEmpty(playfield, p);

            while (!isFieldEmpty)
            {
                p = CreatePoint(x, y);
                isFieldEmpty = IsFieldEmpty(playfield, p);
            }

            return p;
        }

        public static int[,] SetGeneratedPoint(int[,] playfield, ETileType type)
        {
            Point p = GeneratePoint(playfield);
            playfield[p.x, p.y] = (int)type;

            return playfield;
        }

        public static bool IsFieldEmpty(int[,] playfield, Point p)
        {
            if (playfield[p.x, p.y] != 0)
            {
                return false;
            }

            return true;
        }

        public static Point[] DiscoverFields(int[,] playfield, ETileType type)
        {
            Point[] points = new Point[CalculateTileOccurance(playfield, ETileType.SPAWNING_POOL)];
            int count = 0;

            for (int i = 0; i < playfield.GetLength(1); i++)
            {
                for (int j = 0; j < playfield.GetLength(0); j++)
                {
                    if (playfield[j, i] == (int)type)
                    {
                        Point p = new Point();

                        p.x = j;
                        p.y = i;

                        points[count++] = p;
                    }
                }
            }

            return points;
        }

        public static int CalculateTileOccurance(int[,] playfield, ETileType type)
        {
            int count = 0;

            for (int i = 0; i < playfield.GetLength(1); i++)
            {
                for (int j = 0; j < playfield.GetLength(0); j++)
                {
                    if (playfield[j, i] == (int)type)
                    {
                        ++count;
                    }
                }
            }

            return count;
        }
    }
}
