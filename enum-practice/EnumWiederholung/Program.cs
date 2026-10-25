using System;
using System.Runtime.Remoting.Channels;
using System.Threading;

namespace EnumWiederholung
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            int[,] playfield = CreatePlayfield(15, 15);

            playfield = SpawnMonsters(playfield);

            for (int i = 0; i < 10; i++)
            {
                playfield = MoveMonsters(playfield);

                Console.Clear();
                PrintArea(playfield);

                Thread.Sleep(1000);
            }
        }
        
        public static EOrientationType GenerateOrientation()
        {
            int orientation = RANDOM.Next(0, 4);
            EOrientationType oType = (EOrientationType)orientation;

            return oType;
        }

        //Schreiben Sie eine Methode die prüft ob sich der Punkt legal ist.
        //Ein Punkt ist legal wenn er sich im Spielfeld befindet und nicht bereits ein
        //Punkt an seiner Stelle liegt
        public static bool IsPointLegal(int[,] playfield, Point p)
        {
            if (playfield[p.x, p.y] != 0 || p.x > playfield.GetLength(0) || p.y > playfield.GetLength(1) || p.x < 0 || p.y < 0)
            {
                return false;
            }

            return true;
        }

        //Schreiben Sie ein Enum EOrientationType. Die Werte von EOrientationType sind:
        //NORTH, SOUTH, WEST, OST

        //In der Methode wird zu einem gegebenem Punkt ein Nachbarpunkt generiert.
        //Der Nachbarpunkt liegt je nach übergebener Richtung nördlich, südlich usw.
        //vom ursprünglichen Punkt

        //Sie müssen nicht prüfen ob der Nachbarpunkt legal ist.
        public static Point CreateNeighbour(Point p, EOrientationType orientation)
        {
            Point neighbour = new Point();
            if (orientation == EOrientationType.NORTH)
            {
                neighbour.y = p.y - 1;
            }
            if (orientation == EOrientationType.OST)
            {
                neighbour.x = p.x + 1;
            }
            if (orientation == EOrientationType.SOUTH)
            {
                neighbour.y = p.y - 1;
            }
            if (orientation == EOrientationType.WEST)
            {
                neighbour.x = p.x - 1;
            }

            return neighbour;
        }

        //Für einen Punkt soll ein beliebiger Nachbarpunkt generiert werden. Sie müssen prüfen
        //ob der Punkt legal ist. Gibt es keinen legalen Nachbarpunkt wird der Punkt selbst
        //zurückgegben
        public static Point GenerateNeighbour(int[,] playfield, Point p)
        {
            Point neighbour = CreateNeighbour(p, EOrientationType.NORTH);

            bool IsLegal1 = IsPointLegal(playfield, neighbour);

            if (IsLegal1 == false)
            {
                neighbour = CreateNeighbour(p, EOrientationType.OST);

                bool IsLegal2 = IsPointLegal(playfield, neighbour);

                if (IsLegal2 == false)
                {
                    neighbour = CreateNeighbour(p, EOrientationType.SOUTH);

                    bool IsLegal3 = IsPointLegal(playfield, neighbour);

                    if (IsLegal3 == false)
                    {
                        neighbour = CreateNeighbour(p, EOrientationType.WEST);

                        bool IsLegal4 = IsPointLegal(playfield, neighbour);

                        if (IsLegal4 == false)
                        {
                            return p;
                        }
                    }
                }
            }

            return neighbour;
        }

        //Setze ein Feld auf den Spielfeld auf einen gegebenen Typ. Es muss nicht geprüft werden ob der
        //Punkt legal ist
        public static int[,] SetPoint(int[,] playfield, Point p, ETileType type)
        {
            playfield[p.x, p.y] = (int)type;

            return playfield;
        }

        //Bewegt ein Feld von einem Punkt auf dem Spielfeld auf einen anderen Punkt
        //Es muß nicht geprüft werden ob die Punkte legal sind
        public static int[,] MovePoint(int[,] playfield, Point source, Point target)
        {
            playfield[target.x, target.y] = playfield[source.x, source.y];
            playfield[source.x, source.y] = 0;

            return playfield;
        }

        //Auf allen Nachbarfeldern eines Spawningpools soll ein Monster generiert werden
        //Das Monster wird nur generiert wenn es ein legales freies Nachbarfeld gibt
        //Verwenden Sie bereits geschriebene Methoden 
        public static int[,] SpawnMonsters(int[,] playfield)
        {
            Point p = new Point();

            for (int i = 0; i < playfield.GetLength(1); i++)
            {
                for (int j = 0; j < playfield.GetLength(0); j++)
                {
                    if (playfield[j, i] == 2)
                    {
                        p.x = j;
                        p.y = i;
                    }
                }
            }

            GenerateNeighbour(playfield, p);
            GenerateNeighbour(playfield, p);
            GenerateNeighbour(playfield, p);
            GenerateNeighbour(playfield, p);

            return playfield;
        }

        //Schreiben Sie eine Methode die alle Monster auf dem Spielfeld um ein Feld
        //bewegt falls das möglich ist. Verwenden Sie bereits geschriebene Methoden
        public static int[,] MoveMonsters(int[,] playfield)
        {
            Point source = new Point();
            Point target = new Point();

            for (int i = 0; i < playfield.GetLength(1); i++)
            {
                for (int j = 0; j < playfield.GetLength(0); j++)
                {
                    if (playfield[j, i] == 4)
                    {
                        source.x = j;
                        source.y = i;

                        target.x = source.x + 1;
                        target.y = source.y;
                        bool IsMoveLegal = IsPointLegal(playfield, target);
                        if (IsMoveLegal == true)
                        {
                            MovePoint(playfield, source, target);
                        }
                    }
                }
            }

            return playfield;
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
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        case ETileType.SPAWNING_POOL:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case ETileType.PLAYER:
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ETileType.MONSTER:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.Write(area[j, i]);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Black;
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