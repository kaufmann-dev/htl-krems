using System;

namespace Train {
    public class Landscape {
        private AField[,] _gameBoard = new AField[10,10];
        private Random _random = new Random();

        public Landscape()
        {
            Init();   
        }

        private void Init()
        {
            for (int y = 0; y < _gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < _gameBoard.GetLength(1); x++)
                {
                    _gameBoard[y, x] = GenerateField(x, y);
                }
            }
        }

        public void DisplayField()
        {
            for (int i = 0; i < _gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < _gameBoard.GetLength(1); j++)
                {
                    Console.Write(_gameBoard[i, j].ToString());
                }

                Console.WriteLine();
            }
        }

        private AField GenerateField(int x, int y)
        {
            int randomValue = _random.Next(1, 11);

            if (randomValue < 7) return new Plain(x, y);
            if (randomValue >= 7 && randomValue <= 8) return new Water(x, y);
            return new Hill(x, y);
        }

        public bool IsPointLegal(Point p)
        {
            return p.Y >= 10 || p.X >= 10;
        }
    }
}