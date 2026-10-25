using System;

namespace Algodat {
    public class Algorithm {
        // rekursiv = ich rufe die Methode selbst auf
        // iterativ = schleifen
        public static int AddRec(int x, int y)
        {
            if (x == 0) return y;
            return 1 + AddRec(x - 1, y);
        }

        public static int Mult(int x, int y)
        {
            int value = 0;

            for (int i = x; i > 0; i--)
            {
                value += y;
            }

            return value;
        }

        public static int MultRec(int x, int y)
        {
            if (x == 0) return 0;
            return AddRec(MultRec(x - 1, y), y);
        }

        public static int F(int x)
        {
            if(x < 0) throw new ArgumentOutOfRangeException("number was negative");
            
            if (x == 1 || x == 0) return 1;
            return F(x - 1) * x;
        }
        public static int P(int x, int y)
        {
            if (y == 0) return 1;
            return MultRec(P(x, y - 1), x);
        }

        public static int Fibonacci(int count)
        {
            if (count == 0 || count == 1) return 1;
            return AddRec(Fibonacci(count - 1), Fibonacci(count - 2));
        }

        public static int GGT(int a, int b)
        {
            if (a % b == 0) return b;
            return GGT(b, a % b);
        }

        public static int Modulo(int a, int b)
        {
            if (a < b) return a;
            return Modulo(a - b, b);
        }

        public static bool StupidAssBinarySearch(int[] array, int val, int i)
        {
            if (array.Length - i - 1 < 0) return false;
            if (array[array.Length - i - 1] == val) return true;
            
            return StupidAssBinarySearch(array, val, i + 1);
        }

        public static bool BinarySearch(int[] array, int val, int start, int end)
        {
            if (start > end) return false;
            
            int midIndex = (start + end) / 2;

            if (val == array[midIndex]) return true;
            
            if (val < array[midIndex]) return BinarySearch(array, val, start, midIndex -1);
            if (val > array[midIndex]) return BinarySearch(array, val, midIndex + 1, end);

            return false;
        }

        public static void SelectionSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[minIndex]) minIndex = j;
                }
                
                Swap(a, minIndex, i);
            }
        }

        public static void Swap(int[] a, int j, int i)
        {
            int temp = a[j];

            a[j] = a[i];
            a[i] = temp;
        }
        
        public static void SelectionSort(Apple[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    //if (a[j] < a[minIndex]) minIndex = j;
                    if (a[j].CompareTo(a[minIndex]) == 1) minIndex = j;
                }
                
                Swap(a, minIndex, i);
            }
        }

        public static void Swap(Apple[] a, int j, int i)
        {
            Apple temp = a[j];

            a[j] = a[i];
            a[i] = temp;
        }
        
        public static void Sort<T>(T[] arr) where T :
            IComparable<T> {
            int n = arr.Length;
            int minIndex = 0;
            for (int i = 0; i < n - 1; i++) {
                minIndex = i;
                for (int j = i; j < n; j++) {
                    if (arr[minIndex].CompareTo(arr[j]) == 1) {
                        minIndex = j;
                    }
                }
                Swap(arr, minIndex, i);
            }
        }
        
        private static void Swap<T>(T[] a, int i, int j) where T
            : IComparable<T> {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}