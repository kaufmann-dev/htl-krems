using System;
using System.Text;

namespace chessoop
{
    public class GameEngine
    {
        private AGameObject[,] _chessboard;

        public AGameObject[,] Chessboard { get; set; }

        public GameEngine(AGameObject[,] chessboard)
        {
            this._chessboard = chessboard;
        }

        public void Init()
        {
            //Bishop = Läufer
            //Knight = Pferd
            //Pawn = Bauer
            //Queen = Königin
            //King = König
            //Rook = Turm

            for (int i = 0; i < 8; i++)
            {
                this.Chessboard[i, 1] = new Pawn(i, 1, EPlayerType.BLACK, this);
                this.Chessboard[i, 6] = new Pawn(i, 6, EPlayerType.WHITE, this);
                for (int j = 0; j < 4; j++)
                {
                    this.Chessboard[i, j + 2] = new DefaultField(i, j, EPlayerType.EMPTY, this);
                }
            }

            this._chessboard[0,0] = new Rook(0,0,EPlayerType.BLACK,this);
            this._chessboard[7,0] = new Rook(7,0,EPlayerType.BLACK,this);
            this._chessboard[0,7] = new Rook(7,0,EPlayerType.WHITE,this);
            this._chessboard[7,7] = new Rook(7,7,EPlayerType.WHITE,this);
            
            this._chessboard[1,0] = new Knight(1,0,EPlayerType.BLACK,this);
            this._chessboard[6,0] = new Knight(6,0,EPlayerType.BLACK,this);
            this._chessboard[1,7] = new Knight(1,7,EPlayerType.WHITE,this);
            this._chessboard[6,7] = new Knight(6,7,EPlayerType.WHITE,this);
            
            this._chessboard[2,0] = new Bishop(2,0,EPlayerType.BLACK,this);
            this._chessboard[5,0] = new Bishop(5,0,EPlayerType.BLACK,this);
            this._chessboard[2,7] = new Bishop(2,7,EPlayerType.WHITE,this);
            this._chessboard[5,7] = new Bishop(5,7,EPlayerType.WHITE,this);
            
            this._chessboard[3,0] = new Queen(3,0,EPlayerType.BLACK,this);
            this._chessboard[3,7] = new Queen(3,7,EPlayerType.WHITE,this);
            
            this._chessboard[4,0] = new King(4,0,EPlayerType.BLACK,this);
            this._chessboard[4,7] = new King(4,7,EPlayerType.WHITE,this);
        }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sb.Append(_chessboard[j, i].DisplayValue());
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public bool TakeTurn(Point p1, Point p2)
        {
            AGameObject figure = _chessboard[p1.X, p1.Y];
            return figure.Move(p2);
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}