using System;
using System.Collections.Generic;

namespace SortLib.Search
{
    public class BinaryTree : Tree
    {
        public BinaryTree()
        {
        }

        #region INSERT
        public override void Insert(int key, int value)
        {
            Node thisNode = new Node(Index, key.ToString(), value.ToString(), null);
            Index++;
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
                current = (Convert.ToInt32(key) < Convert.ToInt32(current.Key)) ? current.Left : current.Right;
            }

            if (auxFather != null)
            {
                if (Convert.ToInt32(auxFather.Key) < key)
                    auxFather.Right = thisNode;

                else auxFather.Left = thisNode;
            }
            thisNode.Father = auxFather;
        }
        #endregion

        #region SEARCH
        public override Node Search(int value)
        {
            return Search(value, Root);
        }

        private Node Search(int targetValue, Node current)
        {
            if (current == null) return null;

            if (targetValue == Convert.ToInt32(current.Value)) return current;
            
            current = targetValue < Convert.ToInt32(current.Value) ? current.Left : current.Right;

            if (current != null) return Search(targetValue, current);

            return null;
        }
        #endregion

        #region REMOVE
        public override bool Remove(int value)
        {
            return SearchRemove(value, Root) != null;
        }
        private Node SearchRemove(int targetValue, Node current)
        {
            if (current == null) return null;

            if (targetValue == Convert.ToInt32(current.Value))
            {
                bool removed = Remove(current);
                return removed ? null : current;
            }
            current = targetValue < Convert.ToInt32(current.Value) ? current.Left : current.Right;

            if (current != null) return SearchRemove(targetValue, current);

            return null;
        }
        private bool Remove(Node current)
        {
            #region the target is a LEAF
            if (current.IsLeaf())
            {
                //the target is left node
                if (Convert.ToInt32(current.Value) < Convert.ToInt32(current.Father.Value))
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
                    if (Convert.ToInt32(current.Value) < Convert.ToInt32(current.Father.Value))
                        current.Father.Left = current.Left;
                    else
                        current.Father.Right = current.Left;

                    current.Left.Father = current.Father;
                }
                else
                {
                    //the target is right node
                    if (Convert.ToInt32(current.Value) < Convert.ToInt32(current.Father.Value))
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
                if (Convert.ToInt32(current.Father.Value) < Convert.ToInt32(current.Value))
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
        
        public override string InOrder()
        {
            InOrder(Root);
            string aux = OrderPath.ToString();
            OrderPath.Clear();
            return aux;
        }
        public override string PosOrder()
        {
            PosOrder(Root);
            string aux = OrderPath.ToString();
            OrderPath.Clear();
            return aux;
        }
        public override string PreOrder()
        {
            PreOrder(Root);
            string aux = OrderPath.ToString();
            OrderPath.Clear();
            return aux;
        }

        public override void Insert(string key, string value)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(string value)
        {
            throw new NotImplementedException();
        }

        public override Node Search(string key)
        {
            throw new NotImplementedException();
        }
    }

}
