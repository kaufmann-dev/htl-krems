namespace chessoop
{
    public class Queen : AGameObject
    {
        public Queen(int x, int y , EPlayerType playerType, GameEngine gameEngine) : base(x, y, playerType, gameEngine)
        {
            
        }

        public override bool IsMoveLegal(Point p)
        {
            if (p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7 && this.IsOpponentOrEmpty(p)) // Generic
            {
                if (Difference(this.Y, p.Y) == Difference(this.X, p.X) || Difference(this.Y, p.Y) == 0 || Difference(this.X, p.X) == 0)
                {
                    if (p.X == this.X && p.Y < this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X, this.Y - i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X > this.X && p.Y < this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X + i, this.Y - i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X > this.X && p.Y == this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X + i, this.Y);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X > this.X && p.Y > this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X + i, this.Y + i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X == this.X && p.Y > this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X, this.Y + i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X < this.X && p.Y > this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X - i, this.Y + i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X < this.X && p.Y == this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X - i, this.Y);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
                        {
                            return true;
                        }
                    }
                    else if (p.X < this.X && p.Y < this.Y)
                    {
                        int count = 0;
                        for (int i = 1; i < Difference(p.Y, this.Y); i++)
                        {
                            Point y = new Point(this.X - i, this.Y - i);
                            if (IsEmpty(y))
                            {
                                count++;
                            }
                        }
                        if (count == Difference(p.Y, this.Y) - 1)
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
            return "Q";
        }
    }
}