using chessoop;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIsEqual()
        {
            Point p1 = new Point(4, 3);
            Point p2 = new Point(3, 2);
            Point p3 = new Point(4, 3);
            Assert.False(p1.IsEqual(p2));
            Assert.True(p1.IsEqual(p3));
        }

        [Test]
        public void TestIsMoveLegalPawn()
        {
            AGameObject[,] chessboard = new AGameObject[8, 8];
            GameEngine gameEngine = new GameEngine(chessboard);
            gameEngine.Init();
            Point p1 = new Point(3, 2);
            Point p2 = new Point(5, 5);
            Assert.True(gameEngine.Chessboard[3, 1].IsMoveLegal(p1));
            Assert.False(gameEngine.Chessboard[3, 1].IsMoveLegal(p2));
        }

        [Test]
        public void TestIsMoveLegalRook()
        {
            AGameObject[,] chessboard = new AGameObject[8, 8];
            GameEngine gameEngine = new GameEngine(chessboard);
            gameEngine.Init();
            Point p2 = new Point(5, 5);
            Assert.False(gameEngine.Chessboard[0, 0].IsMoveLegal(p2));
        }
    }
}