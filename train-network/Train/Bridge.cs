namespace Train {
    public class Bridge :AField {
        public Bridge(int x, int y) : base(x, y)
        {
        }

        public override AField Transform()
        {
            return this;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}