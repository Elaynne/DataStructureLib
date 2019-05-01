using SortLib.Search;
using SortLib.Sort;
using System;
using System.Collections.Generic;
using Xunit;

namespace SortLibTest
{
    public class SortTest
    {
        private readonly int[] intInput = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
        private readonly Dictionary<int, int> dataTree = new Dictionary<int, int> {
            [15] = 200, [18] = 230, [16] = 210, [14] = 190,
            [63] = 680, [12] = 170, [62] = 670, [58] = 630,
            [66] = 710, [26] = 310, [6] = 110, [65] = 700,
            [46] = 510, [11] = 160, [7] = 120
        };
        private readonly int[] expectedInt = new int[] { 6, 7, 11, 12, 14, 15, 16, 18, 26, 46, 58, 62, 63, 65, 66 };
        /*private readonly Dictionary<int, int> expectedTree = new Dictionary<int, int>
        {
            [6] = 110, [7] = 120, [11] = 160, [12] = 170,
            [14] = 190, [15] = 200,[16] = 210, [18] = 230,
            [26] = 310, [46] = 510, [58] = 630, [62] = 670,
            [63] = 680, [65] = 700, [66] = 710,
        };*/
        private readonly string[] strInput = new string[] { "mamão", "arroz", "muito", "simples", "nada", "arara", "matriz" };

        #region integers
        [Fact]
        public void QuicksortTest()
        {
            //arrange
            QuickSort<int> sort = new QuickSort<int>();
            //act
            sort.Quicksort(intInput, 0, intInput.Length - 1);
            int[] result = intInput;
            //assert
            Assert.Equal(expectedInt, result);
        }

        [Fact]
        public void MergesortTest()
        {
            //arrange
            MergeSort<int> sort = new MergeSort<int>();
            //act
            sort.Mergesort(intInput, 0, intInput.Length - 1);
            int[] result = intInput;
            //assert
            Assert.Equal(expectedInt, result);
        }

        [Fact]
        public void HeapsortTest()
        {
            //arrange
            HeapSort sort = new HeapSort();
            int[] result = new int[dataTree.Count];
            int index = 0;
            //act
            foreach (Node node in sort.Heapsort(BuildNodeArray(dataTree)))
            {
                result[index] = Convert.ToInt32(node.Key);
                index++;
            }
            //assert
            Assert.Equal(expectedInt, result);
        }

        private static Node[] BuildNodeArray(Dictionary<int,int> data)
        {
            int index = 0;
            Node[] nodes = new Node[data.Count];

            foreach (KeyValuePair<int,int> item in data)
            {
                nodes[index] = new Node(index, item.Key.ToString(), item.Value.ToString(), null);
                index++;
            }
            return nodes;
        }
        #endregion
    }
}
