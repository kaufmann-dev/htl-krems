using System;

namespace BattleShip {
    public class Move : Point {
        private EFieldtype _fieldtype;
        public EFieldtype Fieldtype { get; set; }
        public Move(int x, int y, EFieldtype fieldtype) : base(x, y)
        {
            this._fieldtype = fieldtype;
        }

        /*public override string ToString()
        {
            switch (_fieldtype)
            {
                case EFieldtype.EMPTY_FIELD:
                    return "░ ";
                case EFieldtype.SHIP_1_A:
                    return "1 ";
                case EFieldtype.SHIP_2_A:
                    return "2 ";
                case EFieldtype.SHIP_3_A:
                    return "3 ";
                case EFieldtype.SHIP_1_B:
                    return "1 ";
                case EFieldtype.SHIP_2_B:
                    return "2 ";
                case EFieldtype.SHIP_3_B:
                    return "3 ";
                case EFieldtype.HIT:
                    return "X ";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }*/
    }
}