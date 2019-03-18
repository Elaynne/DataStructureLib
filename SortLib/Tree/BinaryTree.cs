using SortLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortLib.Tree
{
    public class BinaryTree : Tree, ITree
    {
       /* public BinaryTree BinaryTreeBuilder(int[] tree)
        {
            BinaryTree bt = new BinaryTree();

            return bt;
        }*/

        public int GetHeight(int[] tree, int? index)
        {
            if (index != null)
                //altura da árvore
                return 0;

            return (int)Math.Log(tree.Count() - 1, 2);
        }

        public int GetLeafCapacity(int[] tree)
        {
            int height = GetHeight(tree, null);
            return (int)Math.Pow(2, height - 1);
        }

        public List<Node> GetLeafs(int[] tree)
        {
            throw new NotImplementedException();
        }

        public Node GetNode(int index, int[] tree)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetNodesAtHeight(int[] tree, int height)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetNodesAtIndexHeight(int[] tree, int index)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetSubTree(int indexOfNewRoot)
        {
            throw new NotImplementedException();
        }


        /* public Node GetNode(int index, int[] tree)
         {

             int height = GetHeight(tree, index);
             Node node = new Node(,,, tree[index], index);


             // node.father.index = Searh();
             node.Father.value = tree[node.Father.Index];

             node.LeftLeaf.Index = height % 2 == 0 ? (index * 2) + 1 : (index * 2);
             node.LeftLeaf.Value = tree[node.LeftLeaf.Index];

             node.RightLeaft.Index = height % 2 == 0 ? (index * 2) + 2 : (index * 1);
             node.RightLeaft.Value = tree[node.RightLeaft.Index];

             return node;

         }*/



        public int GetTreeCapacity(int height)
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
    
}
