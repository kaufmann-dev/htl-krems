namespace Train {
    public class Track : AField{
        public Track(int x, int y) : base(x, y)
        {
        }

        public override AField Transform()
        {
            return this;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}