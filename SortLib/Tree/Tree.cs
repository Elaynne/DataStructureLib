using System.Collections.Generic;


namespace SortLib.Tree
{

    public class Node
    {
        internal int value;

        public Node Father { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }
       // public int Key { get; set; }

        public Node(int index, int value, Node father)
        {
            Index = index;
            Left= null;
            Right = null;
           // Key = key;
            Value = value;
            Father = father;
        }
    }

    public class Tree
    {
        private Node Root;
        private int Index;

        public Tree()
        {
            Root = null;
            Index = 0;
        }
        public void Insert(int value)
        {
            Node thisNode = new Node(Index, value, null);
            Index++;
            if (Root == null)
            {
                Root = thisNode;
            }
            else
            {
                Node current = Root;
                Node currentFather = null;
                while (current != null)
                {
                    if (value < current.Value)
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
                if (currentFather.Value < value)
                {
                    currentFather.Right = thisNode;
                    thisNode.Father = currentFather;
                }
                else
                {
                    currentFather.Left = thisNode;
                    thisNode.Father = currentFather;
                }
            }
        }

     
        public void Remove()
        { }
        /* public Node GetMax() {
             return
         }*/
        public void Sort()
        {
        }
    }
    

    
}
