namespace BattleShip {
    public abstract class Field : Point {
        private EFieldtype _fieldtype;
        public EFieldtype Fieldtype => _fieldtype;

        public Field(int x, int y, EFieldtype fieldtype) : base(x, y)
        {
            this._fieldtype = fieldtype;
        }

        public int DisplayValue()
        {
            return (int) _fieldtype;
        }

        public abstract Field Transform();
    }
}