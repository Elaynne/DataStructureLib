﻿using System;
using System.Text;

namespace SortLib.Search
{
    public class BinaryTree<T, G> : Tree<T, G>
    {
        public string BSLog { get; set; }

        public BinaryTree()
        {
        }

      
        #region INSERT
        public override void Insert(T key, G value) => GenericInsert(key,value);

        #endregion

        #region SEARCH
        public override Node<T, G> Search(T key)
        {
            DateTime start = DateTime.Now;
            Node<T, G> aux = Search(key, Root);
            DateTime end = DateTime.Now;
            BSLog = (end - start).ToString();
            return aux;
        }
        #endregion

        #region REMOVE
        public override bool Remove(T key) => SearchRemove(key, Root);

        private bool SearchRemove(T targetValue, Node<T, G> current)
        {
            if (current == null) return false;

            if (Util.ValidateEqual(targetValue, current.Key)) return Remove(current, targetValue);

            current = Util.ValidateLess(targetValue, targetValue, current.Key) ? current.Left : current.Right;

            if (current != null) return SearchRemove(targetValue, current);

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="itemType">the searched object to evaluate the type and compare values</param>
        /// <returns></returns>
        private bool Remove(Node<T, G> current, T itemType)
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
                }
                else {
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
                    if (current.Left != null)
                    {
                        current.Left.Father = current.Father;
                    }
                    else
                    { 
                        current.Right.Father = current.Father;
                    }
                }
                current = current.Left != null ? current.Left : current.Right;
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
                return true;
            }
            return false;
            #endregion
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
