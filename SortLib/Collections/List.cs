using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Collections
{
    public class NodeList<T>
    {
        public T Element { get; set; }
        public NodeList<T> Next { get; set; }
        public NodeList<T> Previous { get; set; }
        public int Index { get; set; }

        public NodeList(T element, NodeList<T> previous, NodeList<T >next, int index)
        {
            Element = element;
            Previous = previous;
            Next = next;
            Index = index;
        }
    }
    public class List<T>
    {
        public int Count { get; set; } = 0;
        public NodeList<T> Head { get; set; }
        public NodeList<T> Tail { get; set; }

        public void Add(T element)
        {
            NodeList<T> aux = null;
            if (Head == null)
            {
                Head = new NodeList<T>(element, null, null, Count);
                Tail = Head;
                Count++;
                return;
            }
            aux = Tail;
            Tail.Next = new NodeList<T>(element,aux,null, Count);
            Tail = Tail.Next;
            Count++;
        }
        /// <summary>
        /// Add a collection to the end of the list
        /// </summary>
        public void AddRange()
        {
        }

        public NodeList<T> Search(object element)
        {
            NodeList<T> auxIdx = Head;
            object obj = auxIdx.Element;

            while (obj != element && auxIdx != null)
            {
                auxIdx = auxIdx.Next;
                obj = auxIdx.Element;
            }
            return (obj == element) ? auxIdx : null;
        }

        public bool Remove(object element)
        {
            NodeList<T> aux = Search(element);
            if (aux == null)
                return false;

            aux.Previous.Next = aux.Next;
            aux.Next.Previous = aux.Previous;
            Count--;
            return true;
        }
        
        public NodeList<T> SearchAt(int index)
        {
            NodeList<T> auxIdx = Head;
            while (auxIdx != null && auxIdx.Index != index)
            {
                auxIdx = auxIdx.Next;
            }
            return (auxIdx != null && auxIdx.Index == index) ? auxIdx : null;
        }
        
        public bool RemoveAt(int index)
        {
            NodeList<T> aux = SearchAt(index);
            if (aux == null)
                return false;

            aux.Previous.Next = aux.Next;
            aux.Next.Previous = aux.Previous;
            Count--;
            return true;
        }

        public void RemoveAll()
        {
        }
        public void RemoveRange(int start, int end)
        {
        }
        public void Clear()
        {
        }
        public void Sort()
        {
        }
        public string PrintList()
        {
            StringBuilder result = new StringBuilder("My list: ");
            NodeList<T> aux = Head;
            while (aux != null)
            {
                result.Append(aux.Element.ToString() + " ");
                aux = aux.Next;
            }
            return result.ToString();
        }
    }
}
