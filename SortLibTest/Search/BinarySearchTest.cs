using SortLib.Search;
using System.Collections.Generic;
using Xunit;

namespace SortLibTest.Search
{
    public class BinarySearchTest
    {
        private readonly int[] intInput = new int[] { 6, 7, 11, 12, 14, 15, 16, 18, 26, 46, 58, 62, 63, 65, 66 };

        #region integers
        [Fact]
        public void BinarySearch_ShouldFind_IntegerTest()
        {
            BinarySearch<int> bs = new BinarySearch<int>();
            int result = bs.Search(intInput, 58);
            int expectedIndex = 10;
            Assert.Equal(expectedIndex, result);
        }
        [Fact]
        public void BinarySearch_ShouldNotFind_IntegerTest()
        {
            BinarySearch<int> bs = new BinarySearch<int>();
            int result = bs.Search(intInput, 99);
            int expectedIndex = -1;
            Assert.Equal(expectedIndex, result);
        }


        #endregion
    }
}
