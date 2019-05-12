using SortLib.Search;
using SortLib.Sort;
using System;
using Xunit;
using SortLib.Collections;

namespace SortLibTest
{
    public class CollectionTest
    {
        private readonly int[] intInput = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
        private readonly int[] expectedInt = new int[] { 6, 7, 11, 12, 14, 15, 16, 18, 26, 46, 58, 62, 63, 65, 66 };
      
        private readonly string[] strInput = new string[] {"mamão", "arroz", "muito", "simples", "nada", "arara", "matriz"};
        private readonly string[] expectedStr = new string[] { "arara", "arroz", "mamão", "matriz", "muito", "nada", "simples" };

        private readonly int[] expectedStackInt = new int[] { 7, 11, 46, 65, 6, 26, 66, 58, 62, 12, 63, 14, 16, 18, 15 };

        #region Queue
        [Fact]
        public void Queue_EnqueueTest()
        {
            //arrange  
            DateTime now = DateTime.Now;
            object[] objInput = new object[] { "string", 103, now, 5547.9 };

            Queue<object> collection = new Queue<object>(objInput.Length);
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
            Queue<object> collection = new Queue<object>(objInput.Length);
            foreach (object obj in objInput)
            {
                collection.Enqueue(obj);
            }
            object[] expected = new object[] { 103, now, 5547.9 };          
            //act
            collection.Dequeue();
            object[] result = collection.GetQueue(); 
            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Queue_IsEmptyTest()
        {
            object[] objInput = new object[] { };
            Queue<object> collection = new Queue<object>(objInput.Length);
            Assert.True(collection.IsEmpty());

        }
        #endregion
        private List<T> BuildList<T>(List<T> collection, T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                collection.Add(data[i]);
            }
            return collection;
        }
       
        #region List
        [Fact]
        public void ListAdd_IntTest()
        {
            //arrange
            List<int> collection = new List<int>();
            //act
            int[] result = BuildList(collection, intInput).GetListElements();
            //assert
            Assert.Equal(intInput, result);
        }      
        [Fact]
        public void ListRemoveElement_IntTest()
        {
            //arrange
            List<int> collection = new List<int>();
            List<int> auxCollection = BuildList(collection, intInput);
            int[] expected = new int[] { 15, 18, 16, 14, 63, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
            //act
            auxCollection.Remove(12);
            int[] result = auxCollection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ListRemoveAt_IntTest()
        {
            //arrange
            List<int> collection = new List<int>();
            List<int> auxCollection = BuildList(collection, intInput);
            int[] expected = new int[] { 15, 18, 16, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
            //act
            auxCollection.RemoveAt(3);
            int[] result = auxCollection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ListClear_IntTest()
        {
            //arrange
            List<int> collection = new List<int>();
            int[] expected = new int[collection.Count];
            //act
            BuildList(collection, intInput).Clear();
            int[] result = collection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ListSort_IntTest()
        {
            //arrange
            List<int> collection = new List<int>();          
            //act
            int[] result = BuildList(collection, intInput).Sort();
            //assert
            Assert.Equal(expectedInt, result);
        }

        [Fact]
        public void ListAdd_StrTest()
        {
            //arrange
            List<string> collection = new List<string>();
            //act
            string[] result = BuildList(collection, strInput).GetListElements();
            //assert
            Assert.Equal(strInput, result);
        }
        [Fact]
        public void ListRemoveElement_StrTest()
        {
            //arrange
            List<string> collection = new List<string>();
            List<string> auxCollection = BuildList(collection, strInput);
            string[] expected = new string[] { "mamão", "arroz", "muito", "simples", "arara", "matriz"};
            //act
            auxCollection.Remove("nada");
            string[] result = auxCollection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ListRemoveAt_StrTest()
        {
            //arrange
            List<string> collection = new List<string>();
            List<string> auxCollection = BuildList(collection, strInput);
            string[] expected = new string[] { "mamão", "arroz", "muito", "simples", "nada", "matriz"};
            //act
            auxCollection.RemoveAt(5);
            string[] result = auxCollection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ListClear_StrTest()
        {
            //arrange
            List<string> collection = new List<string>();
            string[] expected = new string[collection.Count];
            //act
            BuildList(collection, strInput).Clear();
            string[] result = collection.GetListElements();
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ListSort_StrTest()
        {
            //arrange
            List<string> collection = new List<string>();
            //act
            string[] result = BuildList(collection, strInput).Sort();
            //assert
            Assert.Equal(expectedStr, result);
        }
        #endregion

        #region Stack
        [Fact]
        public void StackPush_IntTest()
        {
            //arrange
            Stack<int> collection = new Stack<int>();
            //act
            int[] result = BuildStack(collection, intInput).GetStack();
            //assert
            Assert.Equal(expectedStackInt, result);
        }
        [Fact]
        public void StackPop_IntTest()
        {
            //arrange
            Stack<int> collection = new Stack<int>();
            int[] expected = new int[] { 11, 46, 65, 6, 26, 66, 58, 62, 12, 63, 14, 16, 18, 15 };
            //act
            int top = BuildStack(collection, intInput).Pop();
            int[] result = collection.GetStack();
            //assert
            Assert.Equal(expected, result);
        }
        private Stack<T> BuildStack<T>(Stack<T> collection, T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                collection.Push(data[i]);
            }
            return collection;
        }
        #endregion
    }
}
