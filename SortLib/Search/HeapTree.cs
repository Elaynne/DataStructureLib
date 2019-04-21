
using System;
using System.Text;

namespace SortLib.Search
{
    public class HeapTree 
    {
        public readonly Node[] Heap;
        private readonly int Size;
        private int posix = 0;
        private int Index { get; set; }
        private StringBuilder OrderPath = new StringBuilder();
        public string HeapLog { get; set; }

        public HeapTree(int size)
        {
            Size = size;
            Heap = new Node[size];
            Index = 0;
        }

        /// <summary>
        /// Insert node into end of array and aply heapify on his father, then aply on his father..until aply on root
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(int key, int value)
        {
            DateTime start = DateTime.Now;
            if (posix < Size)
            {
                Node node = new Node(Index, key.ToString(), value.ToString(), null);
                Index++;

                Heap[posix] = node;
                double aux = (double)(posix - 1) / (double)2;
                if (aux > 0)
                    Heapify((posix - 1) / 2, false, false, Size);
                posix++;
            }

            DateTime end = DateTime.Now;
            HeapLog = (end - start).ToString();
        }

        /// <summary>
        /// Always remove root, the new root will be the value of the last index of array
        /// aply heapify on last node with children
        /// </summary>
        /// <returns></returns>
        public Node Remove()
        {
            Node aux = Heap[0];
            Heap[0] = Heap[posix - 1];
            Heapify(0, true, false , Size);
            Heap[posix - 1] = null;
            posix--;
            return aux;
        }

        public void Sort()
        {
            for (int i = Heap.Length - 1; i > 0; i--)
            {
                Swap(0, i);
                Heapify(0, false, true, i);
            }
        }

        private int Left(int i) => i * 2 + 1;
        private int Right(int i) => i * 2 + 2;

        private void Swap(int fatherIdx, int i)
        {
            Node aux = Heap[i];
            //atualization of index to display in order, pos order and pre order
            int fIdx = Heap[fatherIdx].Index;
            int auxIdx = aux.Index;

            Heap[i] = Heap[fatherIdx];
            Heap[i].Index = auxIdx;

            Heap[fatherIdx] = aux;
            Heap[fatherIdx].Index = fIdx;
        }

        /// <summary>
        /// aply on last index with children => Heapify on i = (data.Lenght - 1)/2
        /// then decrement 1 on index and aply
        /// </summary>
        /// <param name="i">index</param>
        /// <param name="remove">condition to change the index where to aply Heapify</param>
        private void Heapify(int i, bool remove, bool sorting, int myLenght)
        {
            int fatherIdx = i;
            int leftIdx = Left(i);
            int rightIdx = Right(i);
            
            if (leftIdx < myLenght && Heap[leftIdx] != null && Convert.ToInt32(Heap[leftIdx].Key) > Convert.ToInt32(Heap[fatherIdx].Key))
            {
                fatherIdx = leftIdx;
            }
            if (rightIdx < myLenght && Heap[rightIdx] != null && Convert.ToInt32(Heap[rightIdx].Key) > Convert.ToInt32(Heap[fatherIdx].Key))
            {
                fatherIdx = rightIdx;
            }
            
            if (fatherIdx != i)
            {
                Swap(fatherIdx, i);
                if (sorting)
                {
                    if (Left(fatherIdx) < Size && Heap[Left(fatherIdx)] != null)
                    {
                        Heapify(fatherIdx, false, sorting, myLenght);
                    }
                }
                else
                {
                    int aux = !remove && ((double)(fatherIdx - 1) / (double)2 > 0) ? (i - 1) / 2 : fatherIdx;
                    Heapify(aux, false, sorting, myLenght);
                }
            } 
        }

        //custom for vector aproach
        private void InOrder(Node node)
        {
            if (node != null)
            {
                if (Left(node.Index) < Size)
                    InOrder(Heap[Left(node.Index)]);
                OrderPath.Append(node.PrintNode());

                if(Right(node.Index) < Size)
                    InOrder(Heap[Right(node.Index)]);
            }
        }
        private void PosOrder(Node node)
        {
            if (node != null)
            {
                if (Left(node.Index) < Size)
                    PosOrder(Heap[Left(node.Index)]);
                if (Right(node.Index) < Size)
                    PosOrder(Heap[Right(node.Index)]);
                OrderPath.Append(node.PrintNode());
            }
        }
        private void PreOrder(Node node)
        {
            if (node != null)
            {
                OrderPath.Append(node.PrintNode());
                if (Left(node.Index) < Size)
                    PreOrder(Heap[Left(node.Index)]);
                if (Right(node.Index) < Size)
                    PreOrder(Heap[Right(node.Index)]);
            }
        }

        public string InOrder()
        {
            InOrder(Heap[0]);
            string aux = OrderPath.ToString();
            OrderPath.Clear();
            return aux;
        }
        public string PosOrder()
        {
            PosOrder(Heap[0]);
            string aux = OrderPath.ToString();
            OrderPath.Clear();
            return aux;
        }
        public string PreOrder()
        {
            PreOrder(Heap[0]);
            string aux = OrderPath.ToString();
            OrderPath.Clear();
            return aux;
        }
    }
}
