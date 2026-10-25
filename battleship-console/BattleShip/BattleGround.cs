namespace BattleShip {
    public class BattleGround {
        private Move[,] playField = new Move[10,10];

        private BattleGround()
        {
            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    //playField[i,j] = new Move(j,i, EFieldtype.EMPTY_FIELD);
                    playField[i, j] = new Move(j, i, EFieldtype.DEFAULT);
                }
            }
        }
    }
}