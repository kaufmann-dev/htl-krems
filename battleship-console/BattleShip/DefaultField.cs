namespace BattleShip {
    public class DefaultField :Field{
        public DefaultField(int x, int y) : base(x, y, EFieldtype.DEFAULT)
        {
            
        }

        public override Field Transform()
        {
            return this;
        }
    }
}