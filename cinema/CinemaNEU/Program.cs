using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaNEU
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[,] cinema = CreateCinema(7, 12);

            for (int i = 0; i < cinema.GetLength(1); i++)
            {
                cinema[i, 6] = 7;
            }

            cinema = BookSeat(4, 4, cinema);

            PrintList(cinema);

            Console.ReadLine();
        }

        public static int[,] CreateCinema(int row, int seat)
        {
            int[,] cinema = new int[seat, row];

            return cinema;
        }

        public static void PrintList(int[,] list)
        {
            for (int i = 0; i < list.GetLength(1); i++)
            {
                for (int j = 0; j < list.GetLength(0); j++)
                {
                    Console.WriteLine(list[j, i]);
                }

                Console.WriteLine();
            }
        }

        public static int[,] BookSeat(int row, int seat, int[,] cinema)
        {
            cinema[seat, row] = 7;

            if (seat > cinema.GetLength(0) || row > cinema.GetLength(1) - 1 || row < 0 || seat < 0 || cinema[seat, row] == 7)
            {
                Console.WriteLine("Error occured");
            }
            else
            {
                cinema[seat, row] = 7;
            }

            return cinema;
        }
    }
}
