
using System;

namespace SortLib.Search
{

    public class AvlTree
    {
        public AvlNode Root { get; set; }

        public AvlTree()
        {
            Root = null;
        }
        
        /// <summary>
        /// Inserts a Key/word into the tree and keeps it balanced
        /// </summary>
        /// <param name="word">The Key of AVLNode</param>
        /// <param name="synonymous"></param>
        public void Insert(string word, string synonymous)
        {
            AvlNode node = new AvlNode(word, synonymous, null, null, null);
            if (Root == null)
                Root = node;
            else
            {
                AvlNode current = Root;
                AvlNode currentFather = null;
                while (current != null)
                {
                    if (string.Compare(word, current.Key) < 0)
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
                if (currentFather != null)
                {
                    if (string.Compare(currentFather.Key, word) < 0)
                    {
                        currentFather.Right = node;
                        node.Father = currentFather;
                    }
                    else
                    {
                        currentFather.Left = node;
                        node.Father = currentFather;
                    }
                }
            }
            AvlNode aux = node;
            Console.WriteLine("\nbalancing for insertion of: " + node.Key);
            while (aux != null)
            {
                int balancing = aux.BalancingFactor();
                Console.WriteLine("\nStarting balancing: " + aux.Key + " balancing factor = " + balancing);
                if (balancing == 2)
                {
                    Console.WriteLine("\nbalancing at: " + aux.Key);
                    if (aux.Right != null && aux.Right.BalancingFactor() == 1)
                    {
                        LRotation(aux);
                    }
                    if (aux.Right != null && aux.Right.BalancingFactor() == -1)
                    {
                        RLRotation(aux);
                    }
                }
                else if (balancing == -2)
                {
                    Console.WriteLine("\nbalancing at: " + aux.Key);
                    if (aux.Left.BalancingFactor() == 1)
                    {
                        LRRotation(aux);
                    }
                    if (aux.Left.BalancingFactor() == -1)
                    {
                        RRotation(aux);
                    }
                }
                aux = aux.Father;
            }
        }

        public AvlNode Search(string word)
        {
            AvlNode aux = Root;
            while (aux != null)
            {
                Console.WriteLine(aux.Key + "->");
                if (string.Compare(aux.Key, word) == 0)
                {
                    Console.WriteLine(":\n" + aux.Synonymous);
                    return aux;
                }
                else if (string.Compare(aux.Key, word) < 0)
                {
                    Console.WriteLine(" \nright: " + (aux.Right == null ? "null": aux.Right.Key));
                    aux = aux.Right;
                }
                else
                {
                    Console.WriteLine(" \nleft: " + (aux.Left == null ? "null": aux.Left.Key));
                    aux = aux.Left;
                }
            }
            return null;
        }

        public void LRotation(AvlNode node)
        {
            AvlNode axis = node.Right;
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

        public void RRotation(AvlNode node)
        {
            AvlNode axis = node.Left;
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

        public void LRRotation(AvlNode node)
        {
            LRotation(node.Left);
            RRotation(node);
        }

        public void RLRotation(AvlNode node)
        {
            RRotation(node.Right);
            LRotation(node);
        }

        private void PreOrder(AvlNode node)
        {
            if (node != null)
            {
                node.PrintAvlNode();
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }
        private void InOrder(AvlNode node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                node.PrintAvlNode();
                InOrder(node.Right);
            }
        }
        private void PosOrder(AvlNode node)
        {
            if (node != null)
            {
                PosOrder(node.Left);
                PosOrder(node.Right);
                node.PrintAvlNode();
            }
        }
        public void PreOrder()
        {
            PreOrder(Root);
        }
        public void InOrder()
        {
            InOrder(Root);
        }
        public void PosOrder()
        {
            PosOrder(Root);
        }

    }
}
