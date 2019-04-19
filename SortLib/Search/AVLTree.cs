using System;
using System.Text;

namespace SortLib.Search
{

    public class AvlTree : Tree 
    {
        private StringBuilder log = new StringBuilder();
        public StringBuilder Log { get => log; }

        public AvlTree() : base()
        {
        }

        #region INSERT
        /// <summary>
        /// Inserts a Key/key into the tree and keeps it balanced
        /// </summary>
        /// <param name="key">The Key of AVLNode</param>
        /// <param name="value"></param>
        public override void Insert(string key, string value)
        {
            Node thisNode = new Node(Index, key, value, null);
            Index++;
            if (Root == null)
            {
                Root = thisNode;
                return;
            }
            Node current = Root;
            Node currentFather = null;
            while (current != null)
            {
                currentFather = current;
                current = string.Compare(key, current.Key) < 0 ? current.Left : current.Right;
            }
            if (currentFather != null)
            {
                if (string.Compare(currentFather.Key, key) < 0)
                    currentFather.Right = thisNode;
                
                else currentFather.Left = thisNode;
            }
            thisNode.Father = currentFather;

            Node aux = thisNode;
            log.Append("\nbalancing for insertion of: " + thisNode.Key);
            BalancingSubtree(aux);
        }
        #endregion

        private void BalancingSubtree(Node node)
        {
            while (node != null)
            {
                int balancing = node.BalancingFactor();
                log.Append("\nStarting balancing: " + node.Key + " balancing factor = " + balancing);
                if (balancing == 2)
                {
                    log.Append("\nbalancing at: " + node.Key);
                    if (node.Right != null && node.Right.BalancingFactor() == 1)
                    {
                        LRotation(node);
                    }
                    if (node.Right != null && node.Right.BalancingFactor() == -1)
                    {
                        RLRotation(node);
                    }
                }
                else if (balancing == -2)
                {
                    log.Append("\nbalancing at: " + node.Key);
                    if (node.Left.BalancingFactor() == 1)
                    {
                        LRRotation(node);
                    }
                    if (node.Left.BalancingFactor() == -1)
                    {
                        RRotation(node);
                    }
                }
                node = node.Father;
            }
        }
        #region SEARCH
        public override Node Search(string key)
        {
            return Search(key, Root);
        }

        private Node Search(string targetValue, Node current)
        {
            if (current == null) return null;

            if (string.Compare(targetValue, current.Key) == 0) return current;

            current = string.Compare(targetValue, current.Key) < 0 ? current.Left : current.Right;

            if (current != null) return Search(targetValue, current);

            return null;
        }
        #endregion

        #region REMOVE
        /// <summary>
        /// Search the element, if the element was found: remove then performs balancing on the element's parent.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool Remove(string value) => SearchRemove(value, Root) != null;
        
        private Node SearchRemove(string targetValue, Node current)
        {
            if (current == null) return null;

            if (targetValue == current.Key)
            {
                bool removed = Remove(current);
                return removed ? null : current;
            }
            current =  string.Compare(targetValue, current.Key) < 0 ? current.Left : current.Right;

            if (current != null) return SearchRemove(targetValue, current);

            return null;
        }
        private bool Remove(Node current)
        {
            #region the target is a LEAF
            if (current.IsLeaf())
            {
                //the target is left node
                if (string.Compare(current.Key, current.Father.Key) < 0)
                    current.Father.Left = null;
                else
                    current.Father.Right = null;

                BalancingSubtree(current.Father);
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
                    if (string.Compare(current.Key, current.Father.Key) < 0)
                        current.Father.Left = current.Left;
                    else
                        current.Father.Right = current.Left;
                    current.Left.Father = current.Father;
                }
                else
                {
                    //the target is right node
                    if (string.Compare(current.Key, current.Father.Key) < 0)
                        current.Father.Left = current.Right;
                    else
                        current.Father.Right = current.Right;
                    current.Right.Father = current.Father;
                }

                BalancingSubtree(current.Father);
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
                successor.Father = current.Father;
                if (string.Compare(current.Father.Key, current.Key) < 0)
                    current.Father.Right = successor;
                else
                    current.Father.Left = successor;
                current.Left.Father = current.Right.Father = successor;

                BalancingSubtree(current.Father);
                return true;
            }
            return false;
            #endregion
        }
        #endregion

        #region ROTATIONS
        private void LRotation(Node node)
        {
            Node axis = node.Right;
            if (node.Father == null)
            {
                Root = axis;
                axis.Father = null;
            }
            else if (node == node.Father.Right)
                node.Father.Right = axis;
            else
                node.Father.Left = axis;
            axis.Father = node.Father;
            axis.Left = node;
            node.Father = axis;
            node.Right = null;
        }

        private void RRotation(Node node)
        {
            Node axis = node.Left;
            if (node.Father == null)
            {
                Root = axis;
                axis.Father = null;
            }
            else if (node == node.Father.Left)
                node.Father.Left = axis;
            else
                node.Father.Right = axis;
            axis.Father = node.Father;
            axis.Right = node;
            node.Father = axis;
            node.Left = null;
        }

        private void LRRotation(Node node)
        {
            LRotation(node.Left);
            RRotation(node);
        }

        private void RLRotation(Node node)
        {
            RRotation(node.Right);
            LRotation(node);
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

        /*TO-DO*/
        public override void Insert(int key, int value)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int value)
        {
            throw new NotImplementedException();
        }

        public override Node Search(int key)
        {
            throw new NotImplementedException();
        }
        
    }
}
