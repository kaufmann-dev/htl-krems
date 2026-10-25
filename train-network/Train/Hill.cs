namespace Train {
    public class Hill :AField{
        public Hill(int x, int y) : base(x, y)
        {
        }

        public override AField Transform()
        {
            return new Tunnel(this.X, this.Y);
        }

        public override string ToString()
        {
            return "3";
        }
    }
}