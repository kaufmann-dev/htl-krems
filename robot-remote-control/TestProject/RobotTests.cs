using NUnit.Framework;
using Robo;

namespace TestProject
{
    public class RobotTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Robot robot = new Robot();
            Assert.AreEqual(robot.Label, robot.ToString());
            Assert.AreNotEqual(robot.Label, "exde");
            
            robot.Location = new Point(3, 3);
            
            MoveUpCommand bra = new MoveUpCommand(robot);
            bra.Process();
            Assert.AreEqual(robot.Location.Y, 2);
            Assert.AreNotEqual(robot.Location.Y, 3);
            
            MoveRightCommand bru = new MoveRightCommand(robot);
            bru.Process();
            Assert.AreEqual(robot.Location.X, 4);
            Assert.AreNotEqual(robot.Location.X, 3);

            robot.Location.X = 3;
            robot.Location.Y = 3;
            
            MoveDownCommand bre = new MoveDownCommand(robot);
            bre.Process();
            Assert.AreEqual(robot.Location.Y, 4);
            Assert.AreNotEqual(robot.Location.Y, 3);
            
            MoveLeftCommand bro = new MoveLeftCommand(robot);
            bro.Process();
            Assert.AreEqual(robot.Location.X, 2);
            Assert.AreNotEqual(robot.Location.X, 3);
        }
    }
}