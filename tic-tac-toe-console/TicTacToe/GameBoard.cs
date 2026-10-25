using System;
using System.Runtime.CompilerServices;

namespace TicTacToe {
    public class GameBoard {
        
        private Move[,] playField = new Move[3, 3];
        
        // Es wird ein Onjekt der Klasse GameBoard instanziert und in einem Feld der Klassenvariable gespeichert
        private static GameBoard gameBoard = new GameBoard();

        // Konstruktor kann nur in Klasse aufgerufen werden
        private GameBoard()
        {
            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    playField[i, j] = new Move(i, j, EPlayerType.EMPTY_FIELD);
                }
            }
        }

        public bool Play(Move move)
        {
            if (!IsEmpty(move)) return false;
            playField[move.Y, move.X] = move;
            return true;
        }

        private bool IsEmpty(Point p)
        {
            return playField[p.Y, p.X].PlayerType == EPlayerType.EMPTY_FIELD;
        }

        public static GameBoard GetInstance()
        {
            return GameBoard.gameBoard;
        }

        public void DisplayGameBoard()
        {
            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    Console.Write(playField[i,j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}