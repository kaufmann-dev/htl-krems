using System;
using System.Collections.Generic;
using combatSimOOP;
using NUnit.Framework;

namespace Tests {
    public class GameEngineTests {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestGameEngineMethodes() {
            GameEngine gameEngine = new GameEngine();
            string map = gameEngine.Info();

            Assert.NotNull(map);

            List<ACreature> creatures = new List<ACreature>() {new Archer(1, 2, gameEngine, EPlayerType.PLAYER_1)};
            gameEngine.AddCreatures(creatures);

            Assert.IsTrue(gameEngine.ContainsCreature(new Point(1, 2)));
            Assert.AreEqual(EPlayerType.PLAYER_1, 
                gameEngine.FindCreature(new Point(1, 2)).PlayerType);
            
            
            Assert.IsTrue(gameEngine.IsPointLegal(new Point(0,0)));
            Assert.IsTrue(gameEngine.IsPointLegal(new Point(4,5)));
            Assert.IsFalse(gameEngine.IsPointLegal(new Point (10,20)));
        }

        [Test]
        public void TestAGameObjectMethods() {
            GameEngine gameEngine = new GameEngine();

            Archer a1 = new Archer(1, 1, gameEngine, EPlayerType.PLAYER_1);
            Archer a2 = new Archer(5, 5, gameEngine, EPlayerType.PLAYER_2);
            
            List<ACreature> creatures = new List<ACreature>() {a1, a2};
            gameEngine.AddCreatures(creatures);

            ACreature enemy = a1.FindNextEnemy();
            Assert.IsTrue(enemy.IsEqual(a2));
            Console.WriteLine(a1.CalculateDistance(a2));

            a1.PerformAction();
        }
    }
}