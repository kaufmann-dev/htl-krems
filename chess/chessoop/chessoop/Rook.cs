namespace chessoop
{
    public class Rook : AGameObject
    {
        public Rook(int x, int y , EPlayerType playerType, GameEngine gameEngine) : base(x, y, playerType, gameEngine)
        {
            
        }

        public override bool IsMoveLegal(Point p)
        {
            if (p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7 && this.IsOpponentOrEmpty(p)) // Generic
            {
                if (this.X == p.X)
                {
                    int count = 0;
                    for (int i = 1; i < Difference(this.Y, p.Y); i++)
                    {
                        if (p.Y > this.Y)
                        {
                            Point y = new Point(this.X, this.Y + i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        else if (p.Y < this.Y)
                        {
                            Point y = new Point(this.X, this.Y - i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                    }

                    if (count == Difference(this.Y, p.Y) - 1)
                    {
                        return true;
                    }
                }
                else if (this.Y == p.Y)
                {
                    int count = 0;
                    for (int i = 1; i < Difference(this.X, p.X); i++)
                    {
                        if (p.X > this.X)
                        {
                            Point y = new Point(this.X + i, this.Y);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        else if (p.X < this.X)
                        {
                            Point y = new Point(this.X - i, this.Y);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                    }

                    if (count == Difference(this.X, p.X) - 1)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public override string DisplayValue()
        {
            return "T";
        }
    }
}