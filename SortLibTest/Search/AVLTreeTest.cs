﻿using SortLib.Search;
using System.Collections.Generic;
using Xunit;

namespace SortLibTest.Search
{
    public class AVLTreeTest
    {
        private readonly int[] intInput = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
        private readonly Dictionary<int, int> intTree = new Dictionary<int, int>
        {
            [15] = 200,
            [18] = 230,
            [16] = 210,
            [14] = 190,
            [63] = 680,
            [12] = 170,
            [62] = 670,
            [58] = 630,
            [66] = 710,
            [26] = 310,
            [6] = 110,
            [65] = 700,
            [46] = 510,
            [11] = 160,
            [7] = 120
        };
        private readonly int[] expectedInt = new int[] { 6, 7, 11, 12, 14, 15, 16, 18, 26, 46, 58, 62, 63, 65, 66 };

        private readonly string[] strInput = new string[] { "mamão", "arroz", "muito", "simples", "nada", "arara", "matriz" };
        private readonly Dictionary<string, string> strTree = new Dictionary<string, string>
        {
            ["mamão"] = "110",
            ["arroz"] = "120",
            ["muito"] = "160",
            ["simples"] = "170",
            ["nada"] = "190",
            ["arara"] = "200",
            ["matriz"] = "210"
        };
        private readonly string[] expectedStr = new string[] { "arara", "arroz", "mamão", "matriz", "muito", "nada", "simples" };

        #region integers
        [Fact]
        public void SearchLeaf_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            Node<int, int> node = avl.Search(12);
            //assert
            Assert.Equal(12, node.Key);
        }
        [Fact]
        public void SearchHasOneSubTree_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            Node<int, int> node = avl.Search(6);
            //assert
            Assert.Equal(6, node.Key);
        }
        [Fact]
        public void SearchHasTwoSubTrees_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            Node<int, int> node = avl.Search(14);
            //assert
            Assert.Equal(14, node.Key);
        }
        [Fact]
        public void SearchAndNotFound_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            object expected = avl.Search(800);
            //assert
            Assert.Null(expected);
        }

        [Fact]
        public void RemoveLeaf_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            bool expected = avl.Remove(46);
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveHasOneSubTree_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            bool expected = avl.Remove(58);
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveHasTwoSubTrees_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            bool expected = avl.Remove(26);
            //assert
            Assert.True(expected);
        }
        [Fact]
        public void RemoveNotFound_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            bool expected = avl.Remove(800);
            //assert
            Assert.False(expected);
        }
        [Fact]
        public void InOrder_IntegerTest()
        {
            //arrange
            AvlTree<int, int> avl = new AvlTree<int, int>();
            //act
            for (int i = 0; i < intInput.Length; i++)
            {
                avl.Insert(intInput[i], i);
            }
            string result = avl.InOrder();
            string expected = "6 7 11 12 14 15 16 18 26 46 58 62 63 65 66 ";
            //assert
            Assert.Equal(expected, result);
        }
   /*     [Fact]
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
        }*/
        #endregion

        #region string
        #endregion
    }
}
