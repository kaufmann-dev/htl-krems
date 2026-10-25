namespace Train {
    public class Plain : AField {
        public Plain(int x, int y) : base(x, y)
        {
            
        }


        public override AField Transform()
        {
            return new Track(this.X, this.Y);
        }

        public override string ToString()
        {
            return "1";
        }
    }
}