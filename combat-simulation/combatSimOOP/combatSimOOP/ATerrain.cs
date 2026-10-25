namespace combatSimOOP {
    public abstract class ATerrain : AGameObject {

        private int _movementPenalty;

        public int MovementPenalty => _movementPenalty;

        public ATerrain(int x, int y, GameEngine gameEngine, int movementPenalty, char charValue) : base(x, y, gameEngine, charValue) {
            _movementPenalty = movementPenalty;
        }

    }
}