namespace BattleShip {
    public class ShipPlayer1 :Field{
        public ShipPlayer1(int x, int y) : base(x, y, EFieldtype.SHIP_PLAYER_1)
        {
            
        }

        public override Field Transform()
        {
            return new DamagedShipPlayer1(this.X, this.Y);
        }
    }
}