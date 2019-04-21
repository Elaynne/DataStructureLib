using System.Text;

namespace SortLib.Collections
{
    public class StackNode
    {
        public StackNode Next { get; set; }
        public int Element { get; set; }

        public StackNode(StackNode next, int element)
        {
            Next = next;
            Element = element;
        }
    }

    public class Stack
    {
        public StackNode Top { get; set; }

        public StackNode GetTop() => Top;
        
        public void Push(int element)
        {
            if (Top == null)
                Top = new StackNode(null, element);
            else
            {
                StackNode aux = new StackNode(Top, element);
                Top = aux;
            }
        }

        public StackNode Pop()
        {
            if (Top != null)
            {
                StackNode aux = Top;
                Top = Top.Next;
                aux.Next = null;
                return aux;
            }
            else
                return null;
        }

        public void PrintStack()
        {
            StackNode aux = Top;
            StringBuilder result = new StringBuilder();
            while (aux != null)
            {
                result.Append((aux.Element).ToString() + "\n");
                aux = aux.Next;
            }
        }
    }
}
