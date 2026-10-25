namespace chessoop
{
    public class Knight : AGameObject
    {
        public Knight(int x, int y , EPlayerType playerType, GameEngine gameEngine) : base(x, y, playerType, gameEngine)
        {
            
        }

        public override bool IsMoveLegal(Point p)
        {
            if (p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7 && this.IsOpponentOrEmpty(p)) // Generic
            {
                if (Difference(Difference(this.X, p.X), Difference(this.Y, p.Y)) == 1 && Difference(this.X, p.X) == 2 && Difference(this.Y, p.Y) == 1 || Difference(Difference(this.X, p.X), Difference(this.Y, p.Y)) == 1 && Difference(this.X, p.X) == 1 && Difference(this.Y, p.Y) == 2) // Local
                {
                    return true;
                }
            }
            return false;
        }

        public override string DisplayValue()
        {
            return "S";
        }
    }
}