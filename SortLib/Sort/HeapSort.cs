using SortLib.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Sort
{
    public class HeapSort<T,G>
    {
        private HeapTree<T,G> Tree { get; set; }
        private List<Node<T, G>> Sorted { get; set; }
        public string HSlog { get; set; }

        public HeapSort()
        {
            Sorted = new List<Node<T, G>>();
        }

        public List<Node<T, G>> Heapsort(Node<T, G>[] myInput)
        {
            DateTime start = DateTime.Now;
            BuildHeapTree(myInput);
            Tree.Sort();
            
            foreach (Node<T, G> node in Tree.Heap)
            {
                Sorted.Add(node);
            }
            DateTime end = DateTime.Now;
            HSlog = (end - start).ToString();
            return Sorted;
        }

        private void BuildHeapTree(Node<T, G>[] myInput)
        {
            Tree = new HeapTree<T,G>(myInput.Length);

            for (int i = 0; i < myInput.Length; i++)
            {
                Tree.Insert(myInput[i].Key, myInput[i].Value);
            }
        }
        
}
}
