using System.Collections.Generic;


namespace SortLib.TreeSearch
{

    public class Node
    {
        public Node father { get; set; }
        public Node leftLeaf { get; set; }
        public Node rightLeaft { get; set; }
        public int value { get; set; }
        //public int height { get; set; }
        public int index { get; set; }
    }

    public class Tree
    {
        public int Height { get; set; }
        //max of leafs on max height
        public int Lenght { get; set; }
        //total nodes of the tree
        public int Capacity { get; set; }
        //point to a null father
        public Node Root { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Node> Leafs { get; set; }
    }
}
