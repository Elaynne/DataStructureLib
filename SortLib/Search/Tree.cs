using System;
using System.Collections.Generic;


namespace SortLib.Search
{

    public class Node
    {
        public Node Father { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }//KEY

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

        public Tree()
        {
            Root = null;
        }
        public Node GetRoot()
        {
            return Root;
        }
        public void UpdateTree(Node newTree)
        {
            Root = newTree;
        }
    }
    

    
}
