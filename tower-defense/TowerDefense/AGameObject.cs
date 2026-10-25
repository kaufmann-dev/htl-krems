using System.Net.Mail;

namespace TowerDefense
{
    public abstract class AGameObject : Point
    {
        private int _health;
        private int _movementValue;
        private int _movementPenalty;

        public int Health { get; set; }
        public int MovementValue { get; set; }
        public int MovementPenalty { get; set; }

        public AGameObject(int x, int y, int health, int movementValue, int movementPenalty)
        {
            this._health = health;
            this._movementValue = movementValue;
            this._movementPenalty = movementPenalty;
        }

        public abstract void PerformAction(Map map)
        {
            
        }

        public abstract string DisplayValue()
        {
            
        }
    }
}