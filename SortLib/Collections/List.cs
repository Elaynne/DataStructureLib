using SortLib.Sort;
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
        private DSUtil Util { get; set; }

        public List()
        {
            Util = new DSUtil();
        }

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
        
        public NodeList<T> Find(object element)
        {
            NodeList<T> auxIdx = Head;
            T obj = auxIdx.Element;

            while (!Util.ValidateEqual(obj, element) && auxIdx != null)
            {
                auxIdx = auxIdx.Next;
                obj = auxIdx.Element;
            }
            return (Util.ValidateEqual(obj, element)) ? auxIdx : null;
        }

        public bool Remove(object element)
        {
            NodeList<T> aux = Find(element);
            if (aux == null)
                return false;

            aux.Previous.Next = aux.Next;
            aux.Next.Previous = aux.Previous;
            Count--;
            return true;
        }
        
        public NodeList<T> FindAt(int index)
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
            NodeList<T> aux = FindAt(index);
            if (aux == null)
                return false;

            aux.Previous.Next = aux.Next;
            aux.Next.Previous = aux.Previous;
            Count--;
            return true;
        }
        
        public void Clear() => Head = Tail = null;

        public T[] Sort(T[] data)
        {
            MergeSort<T> sort = new MergeSort<T>();
            sort.Mergesort(data, 0, data.Length);
            return data;
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

        #region ////////////// TO - DO //////////////////////
        /// <summary>
        /// Add a collection to the end of the list
        /// </summary>
        private void AddRange()
        {
        }
        private void FindAll(Predicate<T> match)
        {
        }
        private void RemoveAll(Predicate<T> match)
        {
         
        }
        private void RemoveRange(int start, int end)
        {
        }  
        #endregion
    }
}
