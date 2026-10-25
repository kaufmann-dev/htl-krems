namespace Train {
    public class Tunnel : AField{
        public Tunnel(int x, int y) : base(x, y)
        {
        }

        public override AField Transform()
        {
            return this;
        }

        public override string ToString()
        {
            return "O";
        }
    }
}