using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Search
{
    public class AvlNode
    {

        public AvlNode Father { get; set; }
        public AvlNode Left { get; set; }
        public AvlNode Right { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }

        public AvlNode(int key, int value, AvlNode right, AvlNode left, AvlNode father)
        {
            Index = key;
            Left = null;
            Right = null;
            Value = value;
            Father = father;
        }

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

        /* public void PrintAvlNode()
         {
             Console.Write("palavra: " + "sinonimos: ");
         }*/
    }
}
