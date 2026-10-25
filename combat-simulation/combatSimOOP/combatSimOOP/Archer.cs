using System.Collections.Generic;

namespace combatSimOOP {
    public class Archer : ACreature {
        public Archer(int x, int y, GameEngine gameEngine, EPlayerType playerType) : base(x, y, gameEngine, 'A',
            new List<int> {3,2,1}, 5, 1, 5, 0, playerType) { }
        
    }
}