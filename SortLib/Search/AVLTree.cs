using System;
using System.Text;

namespace SortLib.Search
{

    public class AvlTree<T,G> : Tree<T,G> 
    {
        public string AvlLog { get; set; }

        public AvlTree() : base()
        {
        }

        #region INSERT
        /// <summary>
        /// Inserts a Key into the tree and keeps it balanced
        /// </summary>
        /// <param name="key">The Key of AVLNode</param>
        /// <param name="value"></param>
        public override void Insert(T key, G value)
        {
            Node<T,G> aux = GenericInsert(key, value);
            BalancingSubtree(aux);   
        }
        #endregion

        private void BalancingSubtree(Node<T,G> node)
        {
            while (node != null)
            {
                int balancing = node.BalancingFactor();
                Util.Log = new StringBuilder("\nStarting balancing: " + node.Key + " balancing factor = " + balancing);
                if (balancing == 2)
                {
                    Util.Log.Append("\nbalancing at: " + node.Key);
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
                    Util.Log.Append("\nbalancing at: " + node.Key);
                    if (node.Left != null && node.Left.BalancingFactor() == 1)
                    {
                        LRRotation(node);
                    }
                    if (node.Left != null && node.Left.BalancingFactor() == -1)
                    {
                        RRotation(node);
                    }
                }
                node = node.Father;
            }
        }

        #region SEARCH
        public override Node<T, G> Search(T key)
        {
            DateTime start = DateTime.Now;
            Node<T, G> aux = Search(key, Root);
            DateTime end = DateTime.Now;
            Util.Log = new StringBuilder();
            AvlLog = "Search time: " + (end - start).ToString();
            return aux;
        }
        #endregion

        #region REMOVE
        /// <summary>
        /// Search the element, if the element was found: remove, then performs balancing on the element's parent.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool Remove(T key) => SearchRemove(key, Root);
        
        private bool SearchRemove(T targetValue, Node<T, G> current)
        {
            if (current == null) return true;

            if (Util.ValidateEqual(targetValue, current.Key)) return Remove(current, targetValue);

            current = Util.ValidateLess(targetValue, targetValue, current.Key) ? current.Left : current.Right;

            if (current != null) return SearchRemove(targetValue, current);

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        private bool Remove(Node<T, G> current, object itemType)
        {
            #region the target is a LEAF
            if (current.IsLeaf())
            {
                if (current != Root)
                {
                    if (Util.ValidateLess(itemType, current.Key, current.Father.Key))
                        current.Father.Left = null;
                    else
                        current.Father.Right = null;
                    BalancingSubtree(current.Father);
                }
                else
                {
                    current = null;
                }
                return true;
            }
            #endregion

            #region target has 1 subtree
            else if ((current.Left != null && current.Right == null) || (current.Left == null && current.Right != null))
            {
                if (current.Father != null)
                {
                    //left subtree
                    if (Util.ValidateLess(itemType, current.Key, current.Father.Key))
                        current.Father.Left = current.Left != null ? current.Left : current.Right;
                    else
                        current.Father.Right = current.Left != null ? current.Left : current.Right;
                    current.Left.Father = current.Father;
                }
                current = current.Left != null ? current.Left : current.Right;
                if(current.Father != null)
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
                Node<T, G> successor = GetSuccessor(current.Right);

                if (successor.Right != null)
                {
                    successor.Right.Father = successor.Father;
                    successor.Father.Right = successor.Right;
                }
                else if (successor != current.Right)
                {
                    successor.Father.Left = null;
                }
                current.Value = successor.Value;
                current.Key = successor.Key;
                current.Index = successor.Index;
                if (current.Right == successor)
                {
                    current.Right = null;
                }
                if (current.Father != null)
                    BalancingSubtree(current.Father);
                return true;
            }
            return false;
            #endregion
        }
        #endregion

        #region ROTATIONS
        private void LRotation(Node<T,G> node)
        {
            Node<T, G> axis = node.Right;
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

        private void RRotation(Node<T, G> node)
        {
            Node<T, G> axis = node.Left;
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

        private void LRRotation(Node<T, G> node)
        {
            LRotation(node.Left);
            RRotation(node);
        }

        private void RLRotation(Node<T, G> node)
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
    }
}
