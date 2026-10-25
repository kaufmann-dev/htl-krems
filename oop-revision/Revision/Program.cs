using System;

namespace Revision
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("────────────");

            Creature joni = new Creature();
            joni.name = "Joni der Schlächter";
            joni.beschreibung = "Schlachtet seine Gegner ab";
            joni.movement = 1;
            joni.attackValue = 4;
            joni.defenseValue = 1;
            joni.armorValue = 6;

            Creature franzi = new Creature();
            franzi.name = "Franzi der Drachen";
            franzi.beschreibung = "Reitet auf Drachen";
            franzi.movement = 2;
            franzi.attackValue = 6;
            franzi.defenseValue = 9;
            franzi.armorValue = 0;

            Creature josef = new Creature();
            josef.name = "Josef der Maulwurf";
            josef.beschreibung = "Erlegt seine Gegner von unten";
            josef.movement = 3;
            josef.attackValue = 5;
            josef.defenseValue = 5;
            josef.armorValue = 2;

            PrintStruct(joni);
            PrintStruct(josef);
            PrintStruct(josef);

            Console.WriteLine("────────────");

            int[] CreatureField = new int[3];
            CreatureField[0] = (int)ECreature.JONI;
            CreatureField[1] = (int)ECreature.FRANZI;
            CreatureField[2] = (int)ECreature.JOSEF;

            PrintList(CreatureField);

            Console.WriteLine("────────────");

            Console.WriteLine((int)EFieldType.WATER);
            Console.WriteLine((int)EFieldType.PLAYER_1);
            Console.WriteLine((int)EFieldType.PLAYER_2);

            Console.WriteLine("────────────");

            int[] fieldList = new int[3];
            fieldList[0] = (int)EFieldType.WATER;
            fieldList[1] = (int)EFieldType.PLAYER_1;
            fieldList[2] = (int)EFieldType.PLAYER_2;

            PrintList(fieldList);

            Console.WriteLine("────────────");

            int[] monsterList = new int[4];
            monsterList[0] = (int)Monster.BIG_MONSTER;
            monsterList[1] = (int)Monster.HUGE_MONSTER;
            monsterList[2] = (int)Monster.AGGRESSIVE_MONSTER;
            monsterList[3] = (int)Monster.SMART_MONSTER;

            PrintMonster(monsterList);

            Console.WriteLine("────────────");

            int[] numberList = new int[6];
            numberList[0] = 3;
            numberList[1] = 546;
            numberList[2] = 54654;
            numberList[3] = 89;
            numberList[4] = 1;
            numberList[5] = 99;

            CalculateBiggestAmount(numberList);

            Console.WriteLine("────────────");

            CalculateFaktorielle(5);

            Console.WriteLine("────────────");

            int[] usedList = new int[10];
            usedList[0] = 134;
            usedList[1] = 221;
            usedList[2] = 134;
            usedList[3] = 221;
            usedList[4] = 134;
            usedList[5] = 798;
            usedList[6] = 9;
            usedList[7] = 798;
            usedList[8] = 153;
            usedList[9] = 34534;

            MostUsed(usedList);

            Console.ReadKey();
        }

        // Program Exo Start
        public static void PrintPointList(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i].x);
                Console.WriteLine(points[i].y);
                Console.WriteLine("----------");
            }
        }

        public static int[,] CreateField(int x, int y)
        {
            int[,] field = new int[x, y];

            return field;
        }

        public static int[,] SetTower(int[,] field, int x, int y)
        {
            field[x, y] = (int)EFieldTypeTower.TOWER;

            return field;
        }

        public static Point[] GenerateTowerList(int[,] playfield)
        {
            Point[] tempPoints = new Point[playfield.GetLength(0) * playfield.GetLength(1)];
            int count = 0;

            for (int i = 0; i < playfield.GetLength(0); i++)
            {
                for (int j = 0; j < playfield.GetLength(1); j++)
                {
                    if (playfield[j, i] == (int)EFieldTypeTower.TOWER)
                    {
                        count++;
                    }
                }
            }

            Point[] finalPoints = new Point[count];
            int kek = 0;

            for (int i = 0; i < playfield.GetLength(0); i++)
            {
                for (int j = 0; j < playfield.GetLength(1); j++)
                {
                    if (playfield[j, i] == (int)EFieldTypeTower.TOWER)
                    {
                        finalPoints[kek].x = playfield.GetLength(0);
                        finalPoints[kek].y = playfield.GetLength(1);
                        kek++;
                    }
                }
            }

            return finalPoints;
        }

        public static Point CalculateRandomPoint(int[,] playground)
        {
            Point x = new Point();

            return x;
        }

        public static bool IsLegal(int[,] field, int x, int y)
        {
            if (y >= 0 && y <= field.GetLength(1) && x >= 0 && x <= field.GetLength(0))
            {
                return true;
            }

            return false;
        }
        // Program Exo End

        public static void PrintStruct(Creature x)
        {
            Console.WriteLine("Name: " + x.name);
            Console.WriteLine("Angriffsstärke: " + x.attackValue);
            /*Console.WriteLine("Beschreibung: " + x.beschreibung);
            Console.WriteLine("Fortbewegungsgeschwindigkeit: " + x.movement);
            Console.WriteLine("Verteidigungsstärke: " + x.defenseValue);
            Console.WriteLine("Rüstungsstärke: " + x.armorValue);*/
        }

        public static void PrintList(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
        }

        public static void PrintMonster(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
        }

        public static void CalculateBiggestAmount(int[] numbers)
        {
            int big = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i + 1] >= big)
                {
                    big = numbers[i + 1];
                }
            }

            Console.WriteLine(big + " ist die größte Zahl");
        }

        public static void CalculateFaktorielle(int x)
        {
            int b = x;

            for (int i = 1; i < x; i++)
            {
                b = b * (x - i);
            }

            Console.WriteLine(b);
        }

        public static void MostUsed (int[] x)
        {
            int finalQuantity = 0; // quantity at start (0)
            int finalNumber = 0; // random number (doesn't matter)

            for (int i = 0; i < x.Length; i++)
            {
                int number = x[i];
                int quantity = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    if(x[j] == number)
                    {
                        quantity++;
                    }
                }

                if(quantity > finalQuantity)
                {
                    finalQuantity = quantity;
                    finalNumber = number;
                }
            }

            Console.WriteLine("Die Zahl " + finalNumber + " ist am häufigsten, das heißt " + finalQuantity + " mal, vorgekommen.");
        }
    }
}
