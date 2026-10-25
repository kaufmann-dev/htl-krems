namespace Train {
    public class Station : AField{
        public Station(int x, int y) : base(x, y)
        {
        }

        public override AField Transform()
        {
            return this;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}