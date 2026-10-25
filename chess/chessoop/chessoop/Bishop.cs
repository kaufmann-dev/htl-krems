namespace chessoop
{
    public class Bishop : AGameObject
    {
        public Bishop(int x, int y , EPlayerType playerType, GameEngine gameEngine) : base(x, y, playerType, gameEngine)
        {
            
        }

        public override bool IsMoveLegal(Point p)
        {
            if (p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7 && this.IsOpponentOrEmpty(p)) // Generic
            {
                if (Difference(this.X, p.X) == Difference(this.Y, p.Y))
                {
                    if (p.X < this.X && p.Y < this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.X, this.X); i++)
                        {
                            Point y = new Point(this.X - i, this.Y - i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        
                        if (count == Difference(p.X, this.X) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X < this.X && p.Y > this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.X, this.X); i++)
                        {
                            Point y = new Point(this.X - i, this.Y + i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        
                        if (count == Difference(p.X, this.X) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X > this.X && p.Y < this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.X, this.X); i++)
                        {
                            Point y = new Point(this.X + i, this.Y - i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        
                        if (count == Difference(p.X, this.X) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X > this.X && p.Y > this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.X, this.X); i++)
                        {
                            Point y = new Point(this.X + i, this.Y + i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }

                        if (count == Difference(p.X, this.X) - 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override string DisplayValue()
        {
            return "L";
        }
    }
}