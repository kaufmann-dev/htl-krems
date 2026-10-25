namespace Model.Entities.Meeples; 

public class Pawn : AMeeple{
    
    public Pawn() {
    }

    public Pawn(int x, int y) : base("image/pawn.png",x, y) {
    }
}