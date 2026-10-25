namespace BattleShip {
    public class ShipPlayer2 :Field{
        public ShipPlayer2(int x, int y) : base(x, y, EFieldtype.SHIP_PLAYER_2)
        {
            
        }

        public override Field Transform()
        {
            return new DamagedShipPlayer2(this.X, this.Y);
        }
    }
}