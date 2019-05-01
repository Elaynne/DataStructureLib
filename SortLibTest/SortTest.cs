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
        private readonly Dictionary<int, int> intTree = new Dictionary<int, int> {
            [15] = 200, [18] = 230, [16] = 210, [14] = 190,
            [63] = 680, [12] = 170, [62] = 670, [58] = 630,
            [66] = 710, [26] = 310, [6] = 110, [65] = 700,
            [46] = 510, [11] = 160, [7] = 120
        };
        private readonly int[] expectedInt = new int[] { 6, 7, 11, 12, 14, 15, 16, 18, 26, 46, 58, 62, 63, 65, 66 };
      
        private readonly string[] strInput = new string[] {
            "mamão", "arroz", "muito", "simples", "nada", "arara", "matriz"
        };
        private readonly Dictionary<string, string> strTree = new Dictionary<string, string>
        {
              ["mamão"] = "110", ["arroz"] = "120", ["muito"] = "160", ["simples"] = "170",
              ["nada"] = "190", ["arara"] = "200", ["matriz"] = "210"
        };
        private readonly string[] expectedStr = new string[] {
           "arara", "arroz", "mamão", "matriz", "muito", "nada", "simples"
        };


        #region integers
        [Fact]
        public void Quicksort_IntegerTest()
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
        public void Mergesort_IntegerTest()
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
        public void Heapsort_IntegerTest()
        {
            //arrange
            HeapSort<int,int> sort = new HeapSort<int,int>();
            int[] result = new int[intTree.Count];
            int index = 0;
            //act
            foreach (Node<int,int> node in sort.Heapsort(BuildNodeArray<int,int>(intTree)))
            {
                result[index] = Convert.ToInt32(node.Key);
                index++;
            }
            //assert
            Assert.Equal(expectedInt, result);
        }
        #endregion

        #region string
        [Fact]
        public void Quicksort_StringTest()
        {
            //arrange
            QuickSort<string> sort = new QuickSort<string>();
            //act
            sort.Quicksort(strInput, 0, strInput.Length - 1);
            string[] result = strInput;
            //assert
            Assert.Equal(expectedStr, result);
        }

        [Fact]
        public void Mergesort_StringTest()
        {
            //arrange
            MergeSort<string> sort = new MergeSort<string>();
            //act
            sort.Mergesort(strInput, 0, strInput.Length - 1);
            string[] result = strInput;
            //assert
            Assert.Equal(expectedStr, result);
        }

        [Fact]
        public void Heapsort_StringTest()
        {
            //arrange
            HeapSort<string, string> sort = new HeapSort<string, string>();
            string[] result = new string[strTree.Count];
            int index = 0;
           
            //act
            foreach (Node<string, string> node in sort.Heapsort(BuildNodeArray<string,string>(strTree)))
            {
                result[index] = node.Key;
                index++;
            }
            //assert
            Assert.Equal(expectedStr, result);
        }
        #endregion

        private static Node<T, G>[] BuildNodeArray<T,G>(Dictionary<T,G> data)
        {
            int index = 0;
            Node<T, G>[] nodes = new Node<T, G>[data.Count];

            foreach (KeyValuePair<T, G> item in data)
            {
                nodes[index] = new Node<T, G>(index, item.Key, item.Value, null);
                index++;
            }
            return nodes;
        }
    }
}
