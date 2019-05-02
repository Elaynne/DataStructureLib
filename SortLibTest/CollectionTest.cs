using SortLib.Search;
using SortLib.Sort;
using System;
using System.Collections.Generic;
using Xunit;

namespace SortLibTest
{
    public class CollectionTest
    {
        private readonly int[] intInput = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
        private readonly int[] expectedInt = new int[] { 6, 7, 11, 12, 14, 15, 16, 18, 26, 46, 58, 62, 63, 65, 66 };
      
        private readonly string[] strInput = new string[] {"mamão", "arroz", "muito", "simples", "nada", "arara", "matriz"};
        private readonly string[] expectedStr = new string[] { "arara", "arroz", "mamão", "matriz", "muito", "nada", "simples" };
        
        #region Queue
        [Fact]
        public void Queue_EnqueueTest()
        {
            //arrange  
            DateTime now = DateTime.Now;
            object[] objInput = new object[] { "string", 103, now, 5547.9 };

            SortLib.Collections.Queue<object> collection = new SortLib.Collections.Queue<object>(objInput.Length);
            foreach (object obj in objInput)
            {
                collection.Enqueue(obj);
            }
            //act
            object[] result = collection.GetQueue();
            //assert
            Assert.Equal(objInput, result);
        }
        [Fact]
        public void Queue_DequeueTest()
        {
            //arrange   
            DateTime now = DateTime.Now;
            object[] objInput = new object[] { "string", 103, now, 5547.9 };
            SortLib.Collections.Queue<object> collection = new SortLib.Collections.Queue<object>(objInput.Length);
            foreach (object obj in objInput)
            {
                collection.Enqueue(obj);
            }
            object[] expected = new object[] { 103, now, 5547.9 };          
            int idx = 0;
            //act
            collection.Dequeue();
            object[] result = new object[collection.Lenght];
            for (int i = collection.GetStartIdx(); i <= collection.Lenght; i++)
            {
                result[idx] = collection.GetQueue()[i];
                idx++;
            }
            //assert
            Assert.Equal(expected, result);
        }
        #endregion
        private SortLib.Collections.List<int> BuildList(SortLib.Collections.List<int> collection)
        {
            for (int i = 0; i < intInput.Length; i++)
            {
                collection.Add(intInput[i]);
            }
            return collection;
        }
        #region List
        [Fact]
        public void List_AddTest()
        {
            //arrange
            SortLib.Collections.List<int> collection = new SortLib.Collections.List<int>();
            //act
            int[] result = BuildList(collection).GetListElements();
            //assert
            Assert.Equal(intInput, result);
        }
        
        [Fact]
        public void List_RemoveElementTest()
        {
            //arrange
            SortLib.Collections.List<int> collection = new SortLib.Collections.List<int>();
            SortLib.Collections.List<int> auxCollection = BuildList(collection);
            int[] expected = new int[] { 15, 18, 16, 14, 63, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
            //act
            auxCollection.Remove(12);
            int[] result = auxCollection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void List_RemoveAtTest()
        {
            //arrange
            SortLib.Collections.List<int> collection = new SortLib.Collections.List<int>();
            SortLib.Collections.List<int> auxCollection = BuildList(collection);
            int[] expected = new int[] { 15, 18, 16, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
            //act
            auxCollection.RemoveAt(3);
            int[] result = auxCollection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void List_ClearTest()
        {
            //arrange
            SortLib.Collections.List<int> collection = new SortLib.Collections.List<int>();
            int[] expected = new int[collection.Count];
            //act
            BuildList(collection).Clear();
            int[] result = collection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void List_SortTest()
        {
            //arrange
            SortLib.Collections.List<int> collection = new SortLib.Collections.List<int>();          
            //act
            int[] result = BuildList(collection).Sort();
            //assert
            Assert.Equal(expectedInt, result);
        }
        #endregion
    }
}
