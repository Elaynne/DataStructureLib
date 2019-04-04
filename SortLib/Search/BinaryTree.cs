using System;
using System.Collections.Generic;

namespace SortLib.Search
{
    public class BinaryTree : Tree
    {
        private int Key { get; set; }

        public BinaryTree()
        {
            Key = 0;
        }

        #region INSERT
        public void Insert(int value)
        {
            Node thisNode = new Node(Key, value, null);
            Key++;

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

            if (auxFather != null)
            {
                if (auxFather.Value < value) auxFather.Right = thisNode;

                else auxFather.Left = thisNode;
            }
            thisNode.Father = auxFather;
        }
        #endregion

        #region SEARCH
        public Node Search(int targetValue, Node current, bool remove)
        {
            if (current == null) return null;

            if (targetValue == current.Value)
            {
                if (remove) {
                    bool removed = Remove(current);
                    return removed ? null : current;
                }
                else
                    return current;
            }

            current = targetValue < current.Value ? current.Left : current.Right;

            if (current != null) return Search(targetValue, current, remove);

            return null;
        }
        #endregion

        #region REMOVE
        private bool Remove(Node current)
        {
            #region the target is a LEAF
            if (current.IsLeaf())
            {
                //the target is left node
                if (current.Value < current.Father.Value)
                    current.Father.Left = null;
                else
                    current.Father.Right = null;
                return true;
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

                    current.Left.Father = current.Father;
                }
                else
                {
                    //the target is right node
                    if (current.Value < current.Father.Value)
                        current.Father.Left = current.Right;
                    else 
                        current.Father.Right = current.Right;
                    
                    current.Right.Father = current.Father;
                }
                return true;
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
                if (current.Father.Value < current.Value)
                    current.Father.Right = successor;
                else
                    current.Father.Left = successor;
                current.Left.Father = current.Right.Father = successor;
              
                return true;
            }
            return false;
            #endregion
        }
      
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
        #endregion
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
