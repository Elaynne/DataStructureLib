using System;
using System.Collections.Generic;


namespace SortLib.Tree
{

    public class Node
    {
        public Node Father { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }

        public Node(int index, int value, Node father)
        {
            Index = index;
            Left= null;
            Right = null;
            Value = value;
            Father = father;
        }

        public bool IsLeaf()
        {
            return (Right == null && Left== null);
        }
       
    }

    public class Tree
    {
        protected Node Root { get; set; }
        protected int Index { get; set; }

        public Tree()
        {
            Root = null;
            Index = 0;
        }
        public Node GetRoot()
        {
            return Root;
        }
       

       
       /* public void Display(Node n)
        {
            if (n == null)
                return;

            Display(n.Left);
            Console.Write(" " + n.Value);
            Display(n.Right);
        }*/
    }
    

    
}
