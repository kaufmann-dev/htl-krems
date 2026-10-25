namespace Train {
    public class Water:AField {
        public Water(int x, int y) : base(x, y)
        {
        }

        public override AField Transform()
        {
            return new Bridge(this.X,this.Y);
        }

        public override string ToString()
        {
            return "2";
        }
    }
}