namespace Model.Entities.Meeples; 

public class Knight : AMeeple {

    public Knight() {
        
    }

    public Knight(int x, int y) : base("image/knight.png", x, y) {
    }
}