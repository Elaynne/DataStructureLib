using SortLib.Search;
using System.Collections.Generic;
using Xunit;

namespace SortLibTest.Search
{
    public class BinaryTreeTest
    {
        private readonly int[] intInput = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };     
        private readonly string[] strInput = new string[] {"mamão", "arroz", "muito", "simples", "nada", "arara", "matriz"};
    
        #region integers
        [Fact]
        public void SearchLeaf_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            Node<int, int> node = tree.Search(46);
            //assert
            Assert.Equal(46, node.Key);
        }
        [Fact]
        public void SearchHasOneSubTree_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            Node<int, int> node = tree.Search(6);
            //assert
            Assert.Equal(6, node.Key);
        }
        [Fact]
        public void SearchHasTwoSubTrees_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            Node<int, int> node = tree.Search(63);
            //assert
            Assert.Equal(63, node.Key);
        }
        [Fact]
        public void SearchAndNotFound_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            object expected = tree.Search(800);
            //assert
            Assert.Null(expected);
        }
        [Fact]
        public void RemoveLeaf_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            bool expected = tree.Remove(46);
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveHasOneSubTree_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            bool expected = tree.Remove(58);
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveHasTwoSubTrees_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            bool expected = tree.Remove(63);
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveNotFound_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            bool expected = tree.Remove(800);
            //assert
            Assert.False(expected);
        }
        [Fact]
        public void InOrder_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            string result = tree.InOrder();
            string expected = "6 7 11 12 14 15 16 18 26 46 58 62 63 65 66 ";
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void PreOrder_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            string result = tree.PreOrder();
            string expected = "15 14 12 6 11 7 18 16 63 62 58 26 46 66 65 ";
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void PosOrder_IntegerTest()
        {
            //arrange
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                tree.Insert(intInput[i], i);
            }
            string result = tree.PosOrder();
            string expected = "7 11 6 12 14 16 46 26 58 62 65 66 63 18 15 ";
            //assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region string
        [Fact]
        public void SearchLeaf_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            Node<string, int> node = tree.Search("arara");
            //assert
            Assert.Equal("arara", node.Key);
        }
        [Fact]
        public void SearchHasOneSubTree_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            Node<string, int> node = tree.Search("simples");
            //assert
            Assert.Equal("simples", node.Key);
        }
        [Fact]
        public void SearchHasTwoSubTrees_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            Node<string, int> node = tree.Search("muito");
            //assert
            Assert.Equal("muito", node.Key);
        }
        [Fact]
        public void SearchAndNotFound_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            object expected = tree.Search("MiLady");
            //assert
            Assert.Null(expected);
        }
        [Fact]
        public void RemoveLeaf_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            bool expected = tree.Remove("arara");
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveHasOneSubTree_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            bool expected = tree.Remove("simples");
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveHasTwoSubTrees_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            bool expected = tree.Remove("mamão");
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveNotFound_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            bool expected = tree.Remove("Milady");
            //assert
            Assert.False(expected);
        }
        [Fact]
        public void InOrder_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            string result = tree.InOrder();
            string expected = "arara arroz mamão matriz muito nada simples ";
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void PreOrder_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            string result = tree.PreOrder();
            string expected = "mamão arroz arara muito matriz simples nada ";
            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void PosOrder_StringTest()
        {
            //arrange
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            //act
            for (int i = 0; i < strInput.Length; i++)
            {
                tree.Insert(strInput[i], i);
            }
            string result = tree.PosOrder();
            string expected = "arara arroz matriz nada simples muito mamão ";
            //assert
            Assert.Equal(expected, result);
        }
        #endregion  
    }
}
