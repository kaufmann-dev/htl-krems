using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlefield
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int x = (int)HEAVY_SWORDS_MAN;
            Console.WriteLine(x);

            Console.WriteLine("Hallo Welt!");
            Console.WriteLine();

            int[,] battlefield = CreateBattlefield(5, 6);
            PrintBattlefield(battlefield);
            Console.WriteLine();

            Point[] phalanx = GetUnitPositions(battlefield, EUnitType.PHALANX);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Positionen aller Phalanxe:");
            PrintPositions(phalanx);
            Console.WriteLine();

            Point illegaler = new Point();
            illegaler.x = 300;
            illegaler.y = -2;
            bool legal = IsPointLegal(battlefield, illegaler);
            if (legal == true)
                Console.Write("Legal!");
            else
                Console.Write("Illegal!");

            Console.ReadKey();
        }

        //Programmieren Sie ein enum EBattlefieldRole. Das enum soll folgende
        //Werte speichern:
        //INFANTRY, CAVALARY, ARTILLERIE 

        //Programmieren Sie ein enum EUnitType. Das enum soll folgende Werte
        //beinhalten:
        //HEAVY_SWORDS_MAN, LIGHT_SKIRMISHER, LIGHT_INFRANTRY, PHALANX, CHARRIOT, HEAVY_CAVALARY, LIGHT_CAVALARY,
        //BOWMEN, LONG_BOW

        //Programmieren Sie eine Struktur Unit. Die Struktur soll folgende
        //Daten speichern haben:
        // public struct Unit {
        // public EBattlefieldRole role;
        // public EUnitType type;
        // public int attackValue;
        // public int armor;
        // public int defenseValue;
        // public int movement;
        // public int hitpoints;
        // }

        // Programmieren Sie eine Struktur Point. Die Struktur hat folgende Werte
        // public struct Point {
        // public int x;
        // public int y;
        // }

        public static Random RANDOM = new Random();

        //Die folgende Methode gibt randomisiert einen der Einheitentypen zurück
        public static EUnitType GetEUnitType()
        {
            int count = Enum.GetNames(typeof(EUnitType)).Length;
            int item = RANDOM.Next(0, count);

            EUnitType type = (EUnitType)item;

            return type;
        }

        //Schreiben Sie eine Methode, die ein neues Battlefield anlegt. 
        //Die Dimensionen von des Battlefields werden durch x und y gegeben 
        //Verwenden Sie die GetUnitType Methode um auf jedem Feld des Schlachtfelds 
        //Eine Einheit zu Positionieren 
        public static int[,] CreateBattlefield(int x, int y)
        {
            int[,] battlefield = new int[x, y];

            for (int i = 0; i < battlefield.GetLength(1); i++)
            {
                for (int j = 0; j < battlefield.GetLength(0); j++)
                {
                    EUnitType type = GetEUnitType();
                    battlefield[j, i] = (int)type;
                }
            }

            return battlefield;
        }


        //Schreiben Sie eine Methode, die ein Schlachtfeld auf der Console ausgibt 
        //Verwenden Sie unterschiedliche Farben für unterschiedliche EUnitTypes 
        public static void PrintBattlefield(int[,] battlefield)
        {
            for (int i = 0; i < battlefield.GetLength(1); i++)
            {
                for (int j = 0; j < battlefield.GetLength(0); j++)
                {
                    if (battlefield[j, i] == 0)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (battlefield[j, i] == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (battlefield[j, i] == 2)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    if (battlefield[j, i] == 3)
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (battlefield[j, i] == 4)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    if (battlefield[j, i] == 5)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    if (battlefield[j, i] == 6)
                        Console.ForegroundColor = ConsoleColor.Gray;
                    if (battlefield[j, i] == 7)
                        Console.ForegroundColor = ConsoleColor.White;
                    if (battlefield[j, i] == 8)
                        Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write(battlefield[j, i]);
                }

                Console.WriteLine();
            }
        }

        //Schreiben Sie eine Methode die für einen Einheitentyp alle Positionen 
        //des Einheitstyps auf dem Schlachtfeld ermittelt 
        public static Point[] GetUnitPositions(int[,] battlefield, EUnitType type)
        {
            int x = GetPoints(battlefield, type);

            Point[] list = new Point[x];

            int y = 0;

            for (int i = 0; i < battlefield.GetLength(1); i++)
            {
                for (int j = 0; j < battlefield.GetLength(0); j++)
                {
                    if (battlefield[j, i] == (int)type)
                    {
                        list[y].x = j;
                        list[y].y = i;
                        y++;
                    }
                }
            }

            return list;
        }

        public static int GetPoints(int[,] battlefield, EUnitType type)
        {
            int x = 0;

            for (int i = 0; i < battlefield.GetLength(1); i++)
            {
                for (int j = 0; j < battlefield.GetLength(0); j++)
                {
                    if (battlefield[j, i] == (int)type)
                    {
                        x++;
                    }
                }
            }

            return x;
        }

        //Schreiben Sie eine Methode die eine Liste von Punkten auf der Console ausgibt 
        public static void PrintPositions(Point[] units)
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < units.Length; i++)
            {
                Console.WriteLine(units[i].x + " | " + units[i].y);
            }
        }

        //Schreiben Sie eine Methode die für einen Punkt prüft ob er auf dem Schlachfeld  
        //liegt 
        public static bool IsPointLegal(int[,] battlefield, Point p)
        {
            if (p.x >= battlefield.GetLength(0) && p.y >= battlefield.GetLength(1) && p.x <= 0 && p.y <= 0)
            {
                return true;
            }

            return false;
        }
    }
}