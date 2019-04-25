using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Search
{
    //This algorithm assume that the input is already sorted
    public class BinarySearch<T>
    {
        private DSUtil Util { get; set; }

        public BinarySearch()
        {
            Util = new DSUtil(); 
        }

        //O(1) O(log n)
        public int Search(T[] sortedData, int start, int  end, T element)
        {
            object obj2 = element;

            int i = (end - start) / 2;
            object currentElement = sortedData[i];

            if (Util.ValidateEqual(currentElement, obj2)) return i;

            if (start == end) return -1;

            if (Util.ValidateLess(currentElement, currentElement, obj2)) Search(sortedData, start, i, element);
            
            else Search(sortedData, i, end, element);
            
            return -1;
        }
    }
}
