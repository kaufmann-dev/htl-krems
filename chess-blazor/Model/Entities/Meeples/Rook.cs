namespace Model.Entities.Meeples; 

public class Rook : AMeeple {

    public Rook() : this(0,0) {
        
    }

    public Rook(int x, int y) : base("image/rook.png", x, y) {
    }
}