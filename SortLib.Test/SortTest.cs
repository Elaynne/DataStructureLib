using SortLib.Sort;
using System.Collections.Generic;
using Xunit;

namespace SortLib.Test
{
    public class SortTest
    {
        private int[] smallArray = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };

        [Fact]
        public void QuickSort()
        {
            //Arrange

            QuickSort<int> sort = new QuickSort<int>();
            //Act
           // sort.Quicksort(smallArray, 0, smallArray.Length - 1);
            
            //Assert
            /*
             */
        }
        
    }
}
