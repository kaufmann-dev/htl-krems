namespace Algodat {
    public interface IComparable<T>{
        /*
        * if this < other return -1
        * if this = other return 0
        * if this > other return 1
        */
        int CompareTo(T other);
    }
}