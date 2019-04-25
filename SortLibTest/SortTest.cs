using SortLib.Sort;
using Xunit;

namespace SortLibTest
{
    public class SortTest
    {
        private readonly int[] intInput = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
        private readonly string[] strInput = new string[] { "mamão", "arroz", "muito", "simples", "nada", "arara", "matriz" };

        [Fact]
        public void QuicksortTest()
        {
            //arrange
            int[] expected = new int[] {6,7,11,12,14,15,16,18,26,46,58,62,63,65,66 };
            QuickSort<int> sort = new QuickSort<int>();
            //act
            sort.Quicksort(intInput, 0, intInput.Length - 1);
            int[] result = intInput;
            //assert
            Assert.Equal(expected, result);
        }
    }
}
