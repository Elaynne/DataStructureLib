using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Search
{
    //Espace O(1) Time O(n)
    class HeapTree
    {
        private readonly int[] elements;

        private readonly int size;
        private int Father(int idx) => (idx - 1) / 2;
        private int Left(int idx) => idx * 2 + 1;
        private int Right(int idx) => idx * 2 + 2;

        private bool HasLeftChild(int idx) => Left(idx) < size;
        private bool HasRightChild(int idx) => Right(idx) < size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int idx) => elements[Left(idx)];
        private int GetRightChild(int idx) => elements[Right(idx)];
        private int GetParent(int idx) => elements[Father(idx)];

        public HeapTree(int size)
        {
            elements = new int[size];
        }

        private void Heap(int[] data)
        {
            int i = (int)(data.Length - 1)/ 2;
            int T = 0;//??
            while (i >= 0)
            {
                Heapify(data, T, i);
                i--;
            }
        }
        //aply on last index with children, 
        //Heapify on i = (data.Lenght - 1)/2
        //then decrement 1 on index and aply
        private void Heapify(int[] data, int T, int i)
        {
            int P = i;
            int L = Left(i);
            int R = Right(i);
            if (L < T && data[L] > data[P]) P =L;
            if (R < T && data[R] > data[P]) P = R;

            if (P != i)
            {
                Swap(i, T);//?
                Heapify(data, T, P);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        //insert node into end of array
        //aply heapify on his father, then aply on his father..until aply on root
        public void Insert()
        {
        }

        //always remove root,
        //the new root will be the last index of array
        //aply heapify on last node with children
        public void Remove()
        {
        }
        
        public int MinHeap(int[] data)
        {
            return data[0];
        }
    }
}
