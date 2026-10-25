namespace chessoop
{
    public class King : AGameObject
    {
        public King(int x, int y , EPlayerType playerType, GameEngine gameEngine) : base(x, y, playerType, gameEngine)
        {
            
        }

        public override bool IsMoveLegal(Point p)
        {
            if (p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7 && this.IsOpponentOrEmpty(p)) // Generic
            {
                if (Difference(p.X, this.X) <= 1 && Difference(p.Y, this.Y) <= 1) // Local
                {
                    return true;
                }
            }
            return false;
        }

        public override string DisplayValue()
        {
            return "K";
        }
    }
}