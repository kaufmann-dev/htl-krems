using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("┌──────────────┐");
            Console.WriteLine("  Hello World!");
            Console.WriteLine("└──────────────┘");
            
            GameBoard g = GameBoard.GetInstance();
            g.Play(new Move(1, 1, EPlayerType.PLAYER_1));
            g.DisplayGameBoard();
        }
    }
}