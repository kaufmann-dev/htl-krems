namespace chessoop
{
    public class DefaultField : AGameObject
    {
        public DefaultField(int x, int y , EPlayerType playerType, GameEngine gameEngine) : base(x, y, playerType, gameEngine)
        {
            
        }

        public override bool IsMoveLegal(Point p)
        {
            return false;
        }

        public override string DisplayValue()
        {
            return " ";
        }
    }
}