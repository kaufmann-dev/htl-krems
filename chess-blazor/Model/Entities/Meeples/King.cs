namespace Model.Entities.Meeples; 

public class King : AMeeple {

    public King() {
        
    }

    public King(int x, int y) : base("image/king.png", x, y) {
    }
}