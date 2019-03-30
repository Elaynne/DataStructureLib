using System;
using System.Collections.Generic;

namespace SortLib.Tree
{
    public class BinaryTree : Tree
    {


        public void Insert(int value)
        {
            Node thisNode = new Node(0, value, null);

            if (Root == null)
            {
                Root = thisNode;
                return;
            }
            
            Node current = Root;
            Node auxFather = null;
             
            while (current != null)
            {
                auxFather = current;
                current = (value < current.Value) ? current.Left : current.Right;
            }

            if (auxFather.Value < value) auxFather.Right = thisNode;
            
            else auxFather.Left = thisNode;
            
            thisNode.Father = auxFather;
        }

        public Node Search(int targetValue, Node current, bool remove)
        {
            if (current == null) return null;

            if (targetValue == current.Value)
            {
                if (remove) {
                    current = Remove(targetValue, current);
                    return current ?? null;
                }
                else
                    return current;
            }

            current = targetValue < current.Value ? current.Left : current.Right;

            if (current != null) return Search(targetValue, current, remove);

            return null;
        }

        #region REMOVE
        private Node Remove(int targetValue, Node current)
        {
           
            #region the target is a LEAF
            if (current.Left == null && current.Right == null)
            {
                //the target is left node
                if (current.Value < current.Father.Value)
                    current.Father.Left = null;                  
                else
                    current.Father.Right = null;
                current = null;
                return current;
            }
            #endregion

            #region target has 1 subtree
            else if ((current.Left != null && current.Right == null) || (current.Left == null && current.Right != null))
            {
                //left subtree
                if (current.Left != null)
                {
                    //the target is left node
                    if (current.Value < current.Father.Value)
                        current.Father.Left = current.Left;
                    else
                        current.Father.Right = current.Left;
                    current = null;
                }
                else
                {
                    //the target is right node
                    if (current.Value < current.Father.Value)
                    {
                        current.Father.Left = current.Right;
                        current.Right.Father = current.Father;
                    }
                    else {
                        current.Father.Right = current.Right;
                        current.Right.Father = current.Father;
                    }
                    current = null;
                }
                return current;
            }
            #endregion

            #region target has 2 subtress
            //Select Successor or Predecessor to replace the removed Node.
            //Successor = smallest value from the right subtree; (MY CHOICE)
            //Predecessor = biggest value from the left subtree
            else if (current.Left != null && current.Right != null)
            {
                //Search smallest element from the right
                Node successor = GetSuccessor(current.Right);
                successor.Left = current.Left;
                successor.Right = current.Right;
                successor.Father  = current.Father;
                current = successor;
                return current;
            }
            return current;
            #endregion
        }
        //public List<int> DisplayTreeArray()
        //{
        //    List<int> myTree = new List<int>();
        //    int idx = 0;

        //    while (idx >= 0)
        //    {
        //        myTree.Add(Root.Value);
        //        idx = Root.Index;
        //        R
        //    }
        //    return myTree;
        //}
        //return de minimun element from the targetNode's right children
        private Node GetSuccessor(Node successor)
        {
            if (successor.Left != null)
                successor = GetSuccessor(successor.Left);
            return successor;
        }

        //return de maximun element from the targetNode's left children
        private Node GetPredecessor(Node predecessor)
        {
            if (predecessor.Right != null)
                predecessor = GetPredecessor(predecessor.Right);
            return predecessor;
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
        #endregion

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
