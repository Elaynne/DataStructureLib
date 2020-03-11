using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Search
{
    //This algorithm assume that the input is already sorted
    public class BinarySearch<T> where T : IComparable
    {

        public BinarySearch()
        {
        }

        //O(1) O(log n)
        public int Search(T[] sortedData, T element)
        {
            int start = 0;
            int end = sortedData.Length;
            end -= 1;

            while (start != end)
            {
                var middle = Convert.ToInt32(Math.Ceiling((start + end) / Convert.ToDecimal(2)));
                if (sortedData[middle].CompareTo(element) > 0)
                {
                    end = middle - 1;
                }
                else {
                    start = middle;
                }
            }

            if (sortedData[start].CompareTo(element) == 0)
                return start;
            return -1;
            /*decimal index = ((end - start) / Convert.ToDecimal(2));
            var i = Convert.ToInt32(Math.Ceiling(index) + start);
           
            if (sortedData[i].CompareTo(element) == 0)
                return i;

            if (start == end) return -1;

            if (element.CompareTo(sortedData[i]) < 0)
                return Search(sortedData, start, i, element);
            else
                return Search(sortedData, i, end, element);*/
        }
    }
}
