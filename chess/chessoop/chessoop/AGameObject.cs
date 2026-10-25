using System;

namespace chessoop
{
    public abstract class AGameObject : Point
    {
        protected EPlayerType _playerType;
        protected GameEngine _gameEngine;
        
        public EPlayerType PlayerType { get; set; }
        public GameEngine GameEngine { get; set; }
        
        public AGameObject(int x, int y, EPlayerType playerType, GameEngine gameEngine) : base(x, y)
        {
            this._playerType = playerType;
            this._gameEngine = gameEngine;
        }

        public abstract bool IsMoveLegal(Point p);

        public bool Move(Point p)
        {
            bool flag = IsMoveLegal(p); 
            
            if (flag)
            {
                _gameEngine.Chessboard[X, Y] = new DefaultField(X, Y, EPlayerType.EMPTY, _gameEngine);
                _gameEngine.Chessboard[p.X, p.Y] = this;
            }

            return flag;
        }

        public abstract string DisplayValue();

        public bool IsOpponentOrEmpty(Point p)
        {
            EPlayerType exde = _gameEngine.Chessboard[p.X, p.Y].PlayerType;
            EPlayerType lole = _gameEngine.Chessboard[this.X, this.Y].PlayerType;
            if (exde == lole)
            {
                return false;
            }
            return true;
        }

        public bool IsEmpty(Point p)
        {
            if (_gameEngine.Chessboard[p.X, p.Y].PlayerType == EPlayerType.EMPTY)
            {
                return true;
            }

            return false;
        }

        public int ToPositiveNumber(int x)
        {
            return Math.Abs(x);
        }

        public int Difference(int x, int y)
        {
            return ToPositiveNumber(x - y);
        }
    }
}