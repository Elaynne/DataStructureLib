﻿using SortLib.Interface;
using System.Text;

namespace SortLib.Search
{

    public class Node
    {
        public Node Father { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
        public int Index { get; set; }

        public Node(int index ,string key, string value, Node father)
        {
            Index = index;
            Key = key;
            Left= null;
            Right = null;
            Value = value;
            Father = father;
        }

        public bool IsLeaf() => (Right == null && Left== null);

        public string PrintNode()
        {
            return "Index: " + Index + " key: " + Key + "\n";
        }

        /*AVL NODE PROPERTY*/
        public int Height()
        {
            if (Left == null && Right == null)
            {
                return 0;
            }

            if (Left == null && Right != null)
            {
                return Right.Height() + 1;
            }
            else if (Right == null && Left != null)
            {
                return Left.Height() + 1;
            }
            else
            {
                int hLeft = Left.Height();
                int hRight = Right.Height();
                return hLeft > hRight ? hLeft + 1 : hRight + 1;
            }
        }
        public int BalancingFactor()
        {
            int hRight = 0;
            int hLeft = 0;
            if (Right != null)
            {
                hRight = Right.Height();
                hRight++;
            }
            if (Left != null)
            {
                hLeft = Left.Height();
                hLeft++;
            }
            return (hRight - hLeft);
        }
    }

    public abstract class Tree : ITree
    {
        protected StringBuilder OrderPath = new StringBuilder();
        protected Node Root { get; set; }
        protected int Index { get; set; }

        protected Tree()
        {
            Root = null;
            Index = 0;
        }
        public Node GetRoot() => Root;

        protected void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                OrderPath.Append(node.PrintNode());
                InOrder(node.Right);
            }
        }
        protected void PosOrder(Node node)
        {
            if (node != null)
            {
                PosOrder(node.Left);
                PosOrder(node.Right);
                OrderPath.Append(node.PrintNode());
            }
        }
        protected void PreOrder(Node node)
        {
            if (node != null)
            {
                OrderPath.Append(node.PrintNode());
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }
        //return de minimun element from the targetNode's right children
        protected Node GetSuccessor(Node successor)
        {
            if (successor.Left != null)
                successor = GetSuccessor(successor.Left);
            return successor;
        }

        //return de maximun element from the targetNode's left children
        protected Node GetPredecessor(Node predecessor)
        {
            if (predecessor.Right != null)
                predecessor = GetPredecessor(predecessor.Right);
            return predecessor;
        }

        public abstract void Insert(int key, int value);

        public abstract bool Remove(int value);

        public abstract Node Search(int key);

        public abstract void Insert(string key, string value);

        public abstract bool Remove(string value);

        public abstract Node Search(string key);
        
        public abstract string InOrder();

        public abstract string PreOrder();

        public abstract string PosOrder();
    }    
}
