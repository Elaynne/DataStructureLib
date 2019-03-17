using SortLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortLib.TreeSearch
{
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

        List<Node> ITree.GetSubTree(int indexOfNewRoot)
        {
            throw new NotImplementedException();
        }
    }


    //TO-DO
    public class AVLTree
    {
    }
    public class HeapTree
    {

    }
}
