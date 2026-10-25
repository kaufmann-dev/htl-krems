using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void PrintPlayField(int[,] area)
        {
            for (int i = 0; i < area.GetLength(1); i++)
            {
                for (int j = 0; j < area.GetLength(0); j++)
                {
                    switch((EFieldType)area[j,i])
                    {
                        case EFieldType.DEFAULT:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(area[j,i]);
                            break;
                        case EFieldType.WATER:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(area[j, i]);
                            break;
                        case EFieldType.HILL:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(area[j, i]);
                            break;
                        case EFieldType.WOOD:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(area[j, i]);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(area[j, i]);
                            break;
                    }
                }
            }
        }

        public static Random random = new Random();

        public static int GetRandomNumber(int n)
        {
            int i = random.Next(0, n);

            return i;
        }

        public static EFieldType GenerateFieldType()
        {
            int i = GetRandomNumber(9);

            if (i <= 3)
            {
                return EFieldType.DEFAULT;
            }
            if(i == 4)
            {
                return EFieldType.WATER;
            }
            if(i == 5 || i == 6)
            {
                return EFieldType.HILL;
            }
            if (i >= 7 && i <= 9)
            {
                return EFieldType.WOOD;
            }

            return 0;
        }

        public static int[,] GeneratePlayField(int n, int m)
        {
            int[,] list = new int[n, m];
            EFieldType z;

            for (int i = 0; i < list.GetLength(1); i++)
            {
                for (int j = 0; j < list.GetLength(0); j++)
                {
                    z = GenerateFieldType();
                    switch(z)
                    {
                        case EFieldType.DEFAULT:
                            list[j, i] = (int)EFieldType.DEFAULT;
                            break;
                        case EFieldType.WATER:
                            list[j, i] = (int)EFieldType.WATER;
                            break;
                        case EFieldType.HILL:
                            list[j, i] = (int)EFieldType.HILL;
                            break;
                        case EFieldType.WOOD:
                            list[j, i] = (int)EFieldType.WOOD;
                            break;
                        default:
                            list[j, i] = 0;
                            break;
                    }
                }
            }

            return list;
        }

        public static bool IsValid(Point p, int[,] playfield)
        {
            if (p.x < playfield.GetLength(0) && p.y < playfield.GetLength(1) && p.x >= 0 && p.y >= 0)
            {
                return true;
            }

            return false;
        }

        public static EFieldType Transform(EFieldType fieldType)
        {
            switch(fieldType)
            {
                case EFieldType.DEFAULT:
                    fieldType = EFieldType.TRACK;
                    break;
                case EFieldType.WOOD:
                    fieldType = EFieldType.TRACK;
                    break;
                case EFieldType.WATER:
                    fieldType = EFieldType.BRIDGE;
                    break;
                case EFieldType.HILL:
                    fieldType = EFieldType.TUNNEL;
                    break;
                default:
                    fieldType = EFieldType.TRACK;
                    break;
            }

            return fieldType;
        }

        public static Point[] CalculateRoute(Point start, Point end, int[,] playfield)
        {
            int count = CountRoute(start, end);
            Point[] points = SetPoints(start, end, playfield, count);

            return points;
        }

        // Eigen
        public static Point[] SetPoints(Point start, Point end, int[,] playfield, int count)
        {
            Point[] points = new Point[count];

            /*int c = 0;

            while (start.x != end.x)
            {
                if (start.x > end.x)
                {
                    start.x = start.x - 1;
                    points[c].x = start.x;
                    points[c].y = start.y;
                    c++;
                }
                if (start.x < end.x)
                {
                    start.x = start.x - 1;
                    points[c].x = start.x;
                    points[c].y = start.y;
                    c++;
                }
            }

            while (start.y != end.y)
            {
                if (start.y > end.y)
                {
                    start.y = start.y - 1;
                    points[c].x = start.x;
                    points[c].y = start.y;
                    c++;
                }
                if (start.y < end.y)
                {
                    start.y = start.y - 1;
                    points[c].x = start.x;
                    points[c].y = start.y;
                    c++;
                }
            }*/

            for (int i = 0; i < points.Length; i++)
            {
                if (start.x != end.x)
                {
                    if (start.x > end.x)
                    {
                        start.x = start.x - 1;
                        points[i].x = start.x;
                        points[i].y = start.y;
                    }
                    else
                    {
                        if (start.x < end.x)
                        {
                            start.x = start.x + 1;
                            points[i].x = start.x;
                            points[i].y = start.y;
                        }
                    }
                }
                else
                {
                    if (start.y != end.y)
                    {
                        if (start.y > end.y)
                        {
                            start.y = start.y - 1;
                            points[i].x = start.x;
                            points[i].y = start.y;
                        }
                        else
                        {
                            if (start.y < end.y)
                            {
                                start.y = start.y + 1;
                                points[i].x = start.x;
                                points[i].y = start.y;
                            }
                        }
                    }
                }
            }

            return points;
        }

        // Eigen
        public static int CountRoute(Point start, Point end)
        {
            int count = 0;

            while(start.x != end.x)
            {
                if (start.x > end.x)
                {
                    start.x = start.x - 1;
                    count++;
                }
                if (start.x < end.x)
                {
                    start.x = start.x - 1;
                    count++;
                }
            }

            while(start.y != end.y)
            {
                if (start.y > end.y)
                {
                    start.y = start.y - 1;
                    count++;
                }
                if (start.y < end.y)
                {
                    start.y = start.y - 1;
                    count++;
                }
            }

            return count;
        }

        public static int[,] CreateTrainRoute(Point start, Point end, int[,] playfield)
        {
            Point[] points = CalculateRoute(start, end, playfield);

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < playfield.GetLength(1); j++)
                {
                    for (int k = 0; k < playfield.GetLength(0); k++)
                    {
                        if (points[i].x == k && points[i].y == j)
                        {
                            playfield[k, j] = (int)EFieldType.TRACK;
                        }
                    }
                }
            }

            return playfield;
        }
    }
}
