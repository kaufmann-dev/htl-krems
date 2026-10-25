using System;

namespace Algodat {
    public class Apple : IComparable<Apple>{
        private int _weight;

        private string _name;

        public int Weight
        {
            get => _weight;
            set => _weight = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Apple(int weight, string name)
        {
            this._weight = weight;
            this._name = name;
        }

        public int CompareTo(Apple other)
        {
            return (this._weight < other.Weight) ? -1 : (this._weight == other.Weight) ? 0 : 1;
        }

        public override string ToString()
        {
            return $"{nameof(_weight)}: {_weight}, {nameof(_name)}: {_name}";
        }
    }
}