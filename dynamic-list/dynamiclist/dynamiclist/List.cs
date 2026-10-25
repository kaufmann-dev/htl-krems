using System;
using System.Transactions;

namespace dynamiclist.dynamiclist
{
    public class List<T>
    {
        private Node<T> _root = null;

        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                return;
            }
            
            Add(_root, data);
        }

        public void Add(Node<T> current, T data)
        {
            if (current.Next == null)
            {
                current.Next = new Node<T>(data); 
                return;
            }
            
            Add(current.Next, data);
        }

        public void Display()
        {
            if (_root == null)
            {
                Console.WriteLine("no data");
            }
            Display(_root);
        }

        public void Display(Node<T> current)
        {
            Console.WriteLine(current.Data.ToString());

            if (current.Next != null)
            {
                Display(current.Next);
            }
        }

        public int Count()
        {
            if (_root == null)
            {
                return 0;

            }
            return Count(_root);
            
        }

        public int Count(Node<T> current)
        {
            if (current.Next != null)
            {
                return 1 + Count(current.Next);
            }

            return 1;

        }

        public void AddRoot(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                return;
            }
            
            AddRoot(_root, data);
            
            
        }

        public void AddRoot(Node<T> current, T data)
        {
            Node<T> addroot = new Node<T>(data);
            addroot.Next = _root;
            _root = addroot;

        }
        
        public void Remove(T data)
        {
            if (_root.Data.Equals(data))
                _root = _root.Next;
            
            Remove(_root, data);
        }

        private void Remove(Node<T> node, T data)
        {
            if (node.Next != null)
                if (node.Next.Data.Equals(data))
                {
                    node.Next = node.Next.Next;
                    Remove(node, data);
                }

            if (node.Next != null)
                Remove(node.Next, data);
        }
    }
}