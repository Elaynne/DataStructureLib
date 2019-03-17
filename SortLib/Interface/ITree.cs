using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortLib.Interface
{
    public interface ITree
    {
        /// <summary>
        /// Get the height of the node or the tree if index is null
        /// </summary>
        /// <param name="tree">The array of the tree</param>
        /// <param name="index">index of the node to evaluate height, if its null, it'll be 0 (the tree root)</param>
        /// <returns></returns>
        int GetHeight(int[] tree, int? index);

        /// <summary>
        /// Get the capacity of the tree's leafs
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        int GetLeafCapacity(Tree tree);

        /// <summary>
        /// Get the leafs's node from the tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        List<Node> GetLeafs(Tree tree);

        /// <summary>
        /// Get all nodes of a given heght
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        List<Node> GetNodesAtHeight(Tree tree, int height);//validate heigth

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        List<Node> GetNodesAtIndexHeight(Tree tree, int index);
        //find index in tree
        //find height of the index GetHeight()

        /// <summary>
        /// Get the Node data at tree index 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Node GetNode(int index, Tree tree);

        /// <summary>
        /// Build a new tree where the root is your index and call recursively the leafs of the leafs
        /// </summary>
        /// <param name="indexOfNewRoot"></param>
        /// <returns></returns>
        List<Node> GetSubTree(int indexOfNewRoot);

        /// <summary>
        /// Capacity of a tree with a given height
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        int GetSubTreeCapacity(int height);

        void InOrder();
        void PreOrder();
        void PosOrder();
    }
    public class Node
    {
        public Node father { get; set; }
        public Node leftLeaf { get; set; }
        public Node rightLeaft { get; set; }
        public int value { get; set; }
        //public int height { get; set; }
        public int index { get; set; }
    }

    public class Tree
    {
        public int Height { get; set; }
        //max of leafs on max height
        public int Lenght { get; set; }
        //total nodes of the tree
        public int Capacity { get; set; }
        //point to a null father
        public Node Root { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Node> Leafs { get; set; }
    }

    public class BinaryTree : Tree, ITree
    {
        public BinaryTree BinaryTreeBuilder(int[] tree)
        {
            BinaryTree bt = new BinaryTree();

            return bt;
        }

        public int GetHeight(int[] tree, int? index)
        {
            if (index != null)
                return 0;

            return (int)Math.Log(tree.Count() - 1, 2);
        }

        public int GetLeafCapacity(int[] tree)
        {
            int height = GetHeight(tree, null);
            return (int)Math.Pow(2, height - 1);
        }

        public int GetLeafCapacity(Tree tree)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetLeafs(Tree tree)
        {
            throw new NotImplementedException();
        }

        public Node GetNode(int index, int[] tree)
        {

            int height = GetHeight(tree, index);
            Node node = new Node();
            node.value = tree[index];
            node.index = index;

           // node.father.index = Searh();
            node.father.value = tree[node.father.index];

            node.leftLeaf.index = height % 2 == 0 ? (index * 2) + 1 : (index * 2);
            node.leftLeaf.value = tree[node.leftLeaf.index];

            node.rightLeaft.index = height % 2 == 0 ? (index * 2) + 2 : (index * 1);
            node.rightLeaft.value = tree[node.rightLeaft.index];

            return node;
            
        }

        public Node GetNode(int index, Tree tree)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetNodesAtHeight(Tree tree, int height)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetNodesAtIndexHeight(Tree tree, int index)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetSubTree(int indexOfNewRoot)
        {
            throw new NotImplementedException();
        }
        
        public int GetSubTreeCapacity(int height)
        {
            return (int)Math.Pow(2, (height + 1)) - 1;
        }

        //Search
        public void InOrder()
        {
            throw new NotImplementedException();
        }

        public void PosOrder()
        {
            throw new NotImplementedException();
        }

        public void PreOrder()
        {
            throw new NotImplementedException();
        }
    }


    public class AVLTree
    {
    }
    public class HeapTree
    {

    }


}