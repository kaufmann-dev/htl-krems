using System.Collections.Generic;

namespace combatSimOOP {
    public class Phalanx : ACreature {
        public Phalanx(int x, int y, GameEngine gameEngine, EPlayerType playerType) : base(x, y, gameEngine, 'P',
            new List<int>() {4, 4, 3, 3}, 1, 2, 2, 1, playerType) { }
        
    }
}