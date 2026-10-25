using System;

namespace combatSimOOP {
    public class Dice {
        
        private Random r = new Random();

        public int Roll() {
            return r.Next(1, 7);
        }
        
    }
}