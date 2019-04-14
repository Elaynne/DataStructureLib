using SortLib.Interface;
using System;

namespace SortLib.Search
{

    public class AvlTree : Tree 
    {
        public AvlTree() : base()
        {
        }
        
        /// <summary>
        /// Inserts a Key/key into the tree and keeps it balanced
        /// </summary>
        /// <param name="key">The Key of AVLNode</param>
        /// <param name="synonymous"></param>
        public override void Insert(string key, string value)
        {
            Node node = new Node(key, value, null);
            if (Root == null)
                Root = node;
            else
            {
                Node current = Root;
                Node currentFather = null;
                while (current != null)
                {
                    if (string.Compare(key, current.Key) < 0)
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
                    if (string.Compare(currentFather.Key, key) < 0)
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
            Node aux = node;
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

        public override Node Search(string key)
        {
            Node aux = Root;
            while (aux != null)
            {
                Console.WriteLine(aux.Key + "->");
                if (string.Compare(aux.Key, key) == 0)
                {
                    Console.WriteLine(":\n" + aux.Value);
                    return aux;
                }
                else if (string.Compare(aux.Key, key) < 0)
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

        public override bool Remove(string value)
        {
            throw new NotImplementedException();
        }

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
        
        public override void InOrder()
        {
            InOrder(Root);
        }
        public override void PosOrder()
        {
            PosOrder(Root);
        }
        public override void PreOrder()
        {
            PreOrder(Root);
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
