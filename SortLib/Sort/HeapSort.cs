using Microsoft.Extensions.Configuration;
using SortLib.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Sort
{
    public class HeapSort<T,G>
    {
        private List<Node<T, G>> sorted { get; set; }
        private string duration { get; set; }
        private HeapTree<T,G> Tree { get; set; }

        public List<Node<T, G>> Sorted { get { return sorted; } }
        public string Duration { get { return duration; } }

        private IConfiguration _configuration { get; set; }

        public HeapSort()
        {
            sorted = new List<Node<T, G>>();
        }

        public void SortTime(Node<T, G>[] myInput)
        {
            DateTime start = DateTime.Now;
            Sort(myInput);
            DateTime end = DateTime.Now;
            duration = (end - start).ToString();
        }
        public void Sort(Node<T, G>[] myInput)
        {
            BuildHeapTree(myInput);
            Tree.Sort();
            
            foreach (Node<T, G> node in Tree.Heap)
            {
                sorted.Add(node);
            }
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
