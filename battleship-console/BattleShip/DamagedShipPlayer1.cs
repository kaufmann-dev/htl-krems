namespace BattleShip {
    public class DamagedShipPlayer1 : Field{
        public DamagedShipPlayer1(int x, int y) : base(x, y, EFieldtype.DAMAGED_SHIP_PLAYER_1)
        {
            
        }

        public override Field Transform()
        {
            return this;
        }
    }
}