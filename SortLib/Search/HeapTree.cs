﻿

using System;

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

        /// <summary>
        /// Insert node into end of array and aply heapify on his father, then aply on his father..until aply on root
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(int key, int value)
        {
            if (posix < Size)
            {
                Node node = new Node(key.ToString(), value.ToString(), null);
                Heap[posix] = node;
                double aux = (double)(posix - 1) / (double)2;
                if (aux > 0)
                    Heapify((posix - 1) / 2, false, false, Size);
                posix++;
            }
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
            Heap[i] = Heap[fatherIdx];
            Heap[fatherIdx] = aux;
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
            
            if (leftIdx < myLenght && Heap[leftIdx] != null && Convert.ToInt32(Heap[leftIdx].Value) > Convert.ToInt32(Heap[fatherIdx].Value))
            {
                fatherIdx = leftIdx;
            }
            if (rightIdx < myLenght && Heap[rightIdx] != null && (Convert.ToInt32(Heap[rightIdx].Value) > Convert.ToInt32(Heap[fatherIdx].Value)))
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
                InOrder(Heap[Left(Convert.ToInt32(node.Key))]);
                node.PrintNode();
                InOrder(Heap[Right(Convert.ToInt32(node.Key))]);
            }
        }
        private void PosOrder(Node node)
        {
            if (node != null)
            {
                PosOrder(Heap[Left(Convert.ToInt32(node.Key))]);
                PosOrder(Heap[Right(Convert.ToInt32(node.Key))]);
                node.PrintNode();
            }
        }
        private void PreOrder(Node node)
        {
            if (node != null)
            {
                node.PrintNode();
                PreOrder(Heap[Left(Convert.ToInt32(node.Key))]);
                PreOrder(Heap[Right(Convert.ToInt32(node.Key))]);
            }
        }

        public void InOrder() => InOrder(Heap[0]);
        public void PosOrder() => PosOrder(Heap[0]);
        public void PreOrder() => PreOrder(Heap[0]);

    }
}
