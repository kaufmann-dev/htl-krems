namespace dynamiclist.dynamiclist
{
    public class Node<T>
    {
        private T data;

        private Node<T> _next = null;
        private Node<T> _prev = null;

        public Node<T> Prev
        {
            get => _prev;
            set => _prev = value;
        }


        public T Data
        {
            get => data;
            set => data = value;
        }

        public Node<T> Next
        {
            get => _next;
            set => _next = value;
        }

        public Node(T data)
        {
            this.data = data;
        }
    }
}