using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Search
{
    //Espace O(1) Time O(n)
    class HeapTree 
    {
        private readonly Node[] Heap;
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
                if ((posix - 1) / 2 > 0)
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

        private int Father(int i) => (i - 1) / 2;
        private int Left(int i) => i * 2 + 1;
        private int Right(int i) => i * 2 + 2;

        private void Swap(int P, int i)
        {
            Node aux = Heap[i];
            Heap[i] = Heap[P];
            Heap[P] = aux;
        }

        //aply on last index with children => Heapify on i = (data.Lenght - 1)/2
        //then decrement 1 on index and aply
        private void Heapify(int i, bool remove)
        {
            int P = i;
            int E = Left(i);
            int D = Right(i);
            if (E < Size && Heap[E] != null)
            {
                if (Heap[E].Index > Heap[P].Index)
                    P = E;
            }
            if (D < Size && Heap[D] != null)
            {
                if (Heap[D].Index > Heap[P].Index)
                    P = D;
            }
            if (P != i)
            {
                Swap(P, i);
                int aux = P;
                if (!remove && ((P - 1) / 2 > 0))
                {
                    aux = (i - 1) / 2;
                    Heapify(aux, false);
                }
                else {
                    Heapify(aux, true);
                }
            }
        }
    }
}
