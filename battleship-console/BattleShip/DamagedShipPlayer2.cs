namespace BattleShip {
    public class DamagedShipPlayer2 : Field{
        public DamagedShipPlayer2(int x, int y) : base(x, y, EFieldtype.DAMAGED_SHIP_PLAYER_2)
        {
            
        }

        public override Field Transform()
        {
            return this;
        }
    }
}