using System.Text;

namespace SortLib.Collections
{
    public class StackNode<T>
    {
        public StackNode<T> Next { get; set; }
        public T Element { get; set; }

        public StackNode(StackNode<T> next, T element)
        {
            Next = next;
            Element = element;
        }
    }

    public class Stack<T>
    {
        public StackNode<T> Top { get; set; }
        private int lenght = 0;
        public int Lenght { get => lenght; }

        public void Push(T element)
        {
            if (Top == null)
                Top = new StackNode<T>(null, element);
            else
            {
                StackNode<T> aux = new StackNode<T>(Top, element);
                Top = aux;
            }
            lenght++;
        }

        public T Pop()
        {
            if (Top != null)
            {
                StackNode<T> aux = Top;
                Top = Top.Next;
                aux.Next = null;
                lenght--;
                return aux.Element;
            }
            return default(T);
        }

        public string PrintStack()
        {
            StackNode<T> aux = Top;
            StringBuilder result = new StringBuilder();
            while (aux != null)
            {
                result.Append((aux.Element).ToString() + " ");
                aux = aux.Next;
            }
            return result.ToString();
        }

        public T[] GetStack()
        {
            StackNode<T> aux = Top;
            T[] result = new T[Lenght];
            int idx = 0;

            while (aux != null)
            {
                result[idx] = aux.Element;
                aux = aux.Next;
                idx++;
            }
            return result;
        }
    }
}
