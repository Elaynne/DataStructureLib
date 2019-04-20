using System;
using System.Text;

namespace SortLib.Search
{

    public class AvlTree : Tree 
    {
        private readonly StringBuilder log = new StringBuilder();
        public StringBuilder Log { get => log; }

        public AvlTree() : base()
        {
        }

        #region INSERT
        /// <summary>
        /// Inserts a Key into the tree and keeps it balanced
        /// </summary>
        /// <param name="key">The Key of AVLNode</param>
        /// <param name="value"></param>
        public override void Insert(object key, object value)
        {
            Node aux = GenericInsert(key, value);
            log.Append("\nbalancing for insertion of: " + aux.Key);
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
        public override Node Search(object key) => Search(key, Root);
        #endregion

        #region REMOVE
        /// <summary>
        /// Search the element, if the element was found: remove, then performs balancing on the element's parent.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool Remove(object key) => SearchRemove(key, Root);

        private bool SearchRemove(object targetValue, Node current)
        {
            if (current == null) return true;

            if (Util.ValidateEqual(targetValue, current.Key)) return Remove(current, targetValue);

            current = Util.ValidateByType(targetValue, targetValue, current.Key) ? current.Left : current.Right;

            if (current != null) return SearchRemove(targetValue, current);

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        private bool Remove(Node current, object itemType)
        {
            #region the target is a LEAF
            if (current.IsLeaf())
            {
                if (current != Root)
                {
                    if (Util.ValidateByType(itemType, current.Key, current.Father.Key))
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
                    if (Util.ValidateByType(itemType, current.Key, current.Father.Key))
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
                Node successor = GetSuccessor(current.Right);

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
    }
}
