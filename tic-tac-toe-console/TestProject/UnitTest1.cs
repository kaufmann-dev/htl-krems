using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using TicTacToe;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMove()
        {
            Move m = new Move(2, 1, EPlayerType.PLAYER_2);
        }

        public void TestGameBoard()
        {
            GameBoard g1 = GameBoard.GetInstance();
            GameBoard g2 = GameBoard.GetInstance();
            
            Assert.NotNull(g1);
            Assert.NotNull(g2);
            
            Assert.AreSame(g1, g2);
        }
    }
}