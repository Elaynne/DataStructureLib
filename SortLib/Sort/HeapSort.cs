using SortLib.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Sort
{
    public class HeapSort
    {
        private HeapTree Tree { get; set; }
        private List<Node> Sorted { get; set; }
        public string HSlog { get; set; }

        public HeapSort()
        {
            Sorted = new List<Node>();
        }

        public List<Node> Heapsort(Node[] myInput)
        {
            DateTime start = DateTime.Now;
            BuildHeapTree(myInput);
            Tree.Sort();
            
            foreach (Node node in Tree.Heap)
            {
                Sorted.Add(node);
            }
            DateTime end = DateTime.Now;
            HSlog = (end - start).ToString();
            return Sorted;
        }

        private void BuildHeapTree(Node[] myInput)
        {
            Tree = new HeapTree(myInput.Length);

            for (int i = 0; i < myInput.Length; i++)
            {
                Tree.Insert(Convert.ToInt32(myInput[i].Key), Convert.ToInt32(myInput[i].Value));
            }
        }
        
}
}
