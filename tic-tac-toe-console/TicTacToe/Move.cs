using System;

namespace TicTacToe {
    public class Move : Point {
        private EPlayerType _playerType;
        public EPlayerType PlayerType => _playerType;
        
        public Move(int x, int y, EPlayerType playerType) : base(x, y)
        {
            this._playerType = playerType;
        }

        public override string ToString()
        {
            switch (_playerType)
            {
                case EPlayerType.EMPTY_FIELD:
                    return "░ ";
                    break;
                case EPlayerType.PLAYER_1:
                    return "X ";
                    break;
                case EPlayerType.PLAYER_2:
                    return "O ";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}