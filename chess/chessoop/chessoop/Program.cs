using System;

namespace chessoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("------------");
            
            AGameObject[,] chessboard = new AGameObject[8, 8];
            GameEngine gameEngine = new GameEngine(chessboard);
            gameEngine.Init();
            string s = gameEngine.Render();
            Console.WriteLine(s);
        }
    }
}