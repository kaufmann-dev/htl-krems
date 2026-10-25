namespace Model.Entities.Meeples; 

public class Queen : AMeeple {

    public Queen() : this(0,0) {
        
    }

    public Queen(int x, int y) : base("image/queen.png", x, y) {
    }
}