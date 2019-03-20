using SortLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortLib.Tree
{
    public class BinaryTree : Tree
    {
        public void Insert(int value)
        {
            Node thisNode = new Node(Index, value, null);
            Index++;
            if (Root == null)
            {
                Root = thisNode;
            }
            else
            {
                Node current = Root;
                Node currentFather = null;
                while (current != null)
                {
                    if (value < current.Value)
                    {
                        currentFather = current;
                        current = current.Left;
                    }
                    else
                    {
                        currentFather = current;
                        current = current.Right;
                    }
                }
                if (currentFather.Value < value)
                {
                    currentFather.Right = thisNode;
                    thisNode.Father = currentFather;
                }
                else
                {
                    currentFather.Left = thisNode;
                    thisNode.Father = currentFather;
                }
            }
        }

        public int Search(int targetValue, Node current)
        {

            if (current == null)
                return -1;

            if (targetValue == current.Value)
                return Index;

            current = targetValue < current.Value ? current.Left : current.Right;

            if (current != null)
            {
                Index = current.Index;
                int idx = Search(targetValue, current);
                return (idx > 0) ? Index : idx;
            }
            return -1;
        }

        public void Remove(int value)
        {

        }

        //Path
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


        //árvores balanceadas
      /*  public int GetHeight(int[] tree, int? index)
        {
            if (index != null)
                //to-do

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
        

        public Node GetNode(int index, int[] tree)
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

         }



        public int GetTreeCapacity(int height)
        {
            return (int)Math.Pow(2, (height + 1)) - 1;
        }*/

        
    }
    
}
