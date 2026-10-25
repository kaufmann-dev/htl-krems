namespace Model.Entities.Meeples; 

public class Bishop : AMeeple{

    public Bishop() : this(0,0){
        
    }

    public Bishop(int x, int y) : base("image/bishop.png",x, y) {
    }

    
}