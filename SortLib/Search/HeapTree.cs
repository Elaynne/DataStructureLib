using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Search
{
    public class HeapTree 
    {
        public readonly Node[] Heap;
        private readonly int Size;
        private int posix = 0;

        public HeapTree(int size)
        {
            Size = size;
            Heap = new Node[size];
        }

        //insert node into end of array
        //aply heapify on his father, then aply on his father..until aply on root
        public void Insert(int key, int value)
        {
            if (posix < Size)
            {
                Node node = new Node(key, value, null);
                Heap[posix] = node;
                double aux = (double)(posix - 1) / (double)2;
                if (aux > 0)
                    Heapify((posix - 1) / 2, false);
                posix++;
            }
        }

        //always remove root,
        //the new root will be the last index of array
        //aply heapify on last node with children
        public Node Remove()
        {
            Node aux = Heap[0];
            Heap[0] = Heap[posix - 1];
            Heapify(0, true);
            Heap[posix - 1] = null;
            posix--;
            return aux;
        }

        private int Left(int i) => i * 2 + 1;
        private int Right(int i) => i * 2 + 2;

        private void Swap(int fatherIdx, int i)
        {
            Node aux = Heap[i];
            Heap[i] = Heap[fatherIdx];
            Heap[fatherIdx] = aux;
        }

        /// <summary>
        /// aply on last index with children => Heapify on i = (data.Lenght - 1)/2
        /// then decrement 1 on index and aply
        /// </summary>
        /// <param name="i">index</param>
        /// <param name="remove">condition to change the index where to aply Heapify</param>
        private void Heapify(int i, bool remove)
        {
            int fatherIdx = i;
            int leftIdx = Left(i);
            int rightIdx = Right(i);

            if (leftIdx < Size && Heap[leftIdx] != null && Heap[leftIdx].Value > Heap[fatherIdx].Value)
            {
                fatherIdx = leftIdx;
            }
            if (rightIdx < Size && Heap[rightIdx] != null && (Heap[rightIdx].Value > Heap[fatherIdx].Value))
            {
                fatherIdx = rightIdx;
            }
            
            if (fatherIdx != i)
            {
                Swap(fatherIdx, i);
                int aux = !remove && ((double)(fatherIdx - 1) / (double)2 > 0) ? (i - 1) / 2 : fatherIdx;
                Heapify(aux, false);
            }
        }
    }
}
