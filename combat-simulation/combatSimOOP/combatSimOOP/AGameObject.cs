namespace combatSimOOP {
    public abstract class AGameObject : Point {

        protected GameEngine _gameEngine;

        private char _charValue;

        public char CharValue => _charValue;
        
        protected AGameObject(int x, int y, GameEngine gameEngine, char charValue) : base(x, y) {
            this._gameEngine = gameEngine;
            this._charValue = charValue;
        }
        
    }
}