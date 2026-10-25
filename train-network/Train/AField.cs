namespace Train {
    public abstract class AField : Point {

        public abstract AField Transform();
        public AField(int x, int y) : base(x, y)
        {
            
        }

        
    }
}