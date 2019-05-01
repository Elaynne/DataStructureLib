using SortLib.Interface;
using System.Text;

namespace SortLib.Search
{

    public class Node<T,G>
    {
        public Node<T,G> Father { get; set; }
        public Node<T,G> Left { get; set; }
        public Node<T,G> Right { get; set; }
        public G Value { get; set; }
        public T Key { get; set; }
        public int Index { get; set; }

        public Node(int index ,T key, G value, Node<T,G> father)
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

    public abstract class Tree<T,G> : ITree<T, G>
    {
        protected StringBuilder OrderPath = new StringBuilder();
        protected Node<T,G> Root { get; set; }
        protected int Index { get; set; }
        public DSUtil Util { get; set; }

        protected Tree()
        {
            Util = new DSUtil();
            Root = null;
            Index = 0;
        }
        public Node<T,G> GetRoot() => Root;
        
        #region PROTECTED
        protected void InOrder(Node<T,G> node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                OrderPath.Append(node.PrintNode());
                InOrder(node.Right);
            }
        }
        protected void PosOrder(Node<T,G> node)
        {
            if (node != null)
            {
                PosOrder(node.Left);
                PosOrder(node.Right);
                OrderPath.Append(node.PrintNode());
            }
        }
        protected void PreOrder(Node<T,G> node)
        {
            if (node != null)
            {
                OrderPath.Append(node.PrintNode());
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        protected Node<T, G> GenericInsert(T key, G value)
        {
            Node<T, G> thisNode = new Node<T, G>(Index, key, value, null);
            Index++;
            if (Root == null)
            {
                Root = thisNode;
                return Root;
            }
            Node<T, G> current = Root;
            Node<T, G> auxFather = null;

            while (current != null)
            {
                auxFather = current;
                current = Util.ValidateLess(key, key, current.Key) ? current.Left : current.Right;
            }

            if (auxFather != null)
            {
                if (Util.ValidateLess(key, auxFather.Key, key))
                    auxFather.Right = thisNode;
                else auxFather.Left = thisNode;
            }
            thisNode.Father = auxFather;
            return thisNode;
        }      
        protected Node<T,G> Search(object targetValue, Node<T,G> current)
        {
            if (current == null) return null;

            if (Util.ValidateEqual(targetValue, current.Key)) return current;

            current = Util.ValidateLess(targetValue, targetValue, current.Key) ? current.Left : current.Right;

            if (current != null) return Search(targetValue, current);

            return null;
        }

        //return de minimun element from the targetNode's right children
        protected Node<T, G> GetSuccessor(Node<T, G> successor)
        {
            if (successor.Left != null)
                successor = GetSuccessor(successor.Left);
            return successor;
        }
        //return de maximun element from the targetNode's left children
        protected Node<T, G> GetPredecessor(Node<T, G> predecessor)
        {
            if (predecessor.Right != null)
                predecessor = GetPredecessor(predecessor.Right);
            return predecessor;
        }
        #endregion

        #region PUBLIC
        public abstract void Insert(T key, G value);

        public abstract Node<T, G> Search(T key);

        public abstract bool Remove(T key);
        
        public abstract string InOrder();

        public abstract string PreOrder();

        public abstract string PosOrder();
        #endregion
    }
}
