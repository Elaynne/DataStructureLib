using SortLib.Search;
using System;
using System.Text;

namespace SortLib.Sort
{
    public class HeapSort
    {
        private HeapTree Tree { get; set; }

        public void Heapsort(int[] myInput)
        {
            BuildHeapTree(myInput);
            Tree.Sort();

            StringBuilder result = new StringBuilder("Sorted array by heapsort ");

            foreach (Node node in Tree.Heap)
            {
                result.Append(node.Value + " ");
            }
            Console.WriteLine(result);
        }

        private void BuildHeapTree(int[] myInput)
        {
            Tree = new HeapTree(myInput.Length);
            Random rnd = new Random();

            for (int i = 0; i < myInput.Length; i++)
            {
                Tree.Insert(rnd.Next(1, myInput.Length), myInput[i]);
            }
        }
        
}
}
