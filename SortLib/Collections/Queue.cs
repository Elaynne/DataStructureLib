using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Collections
{
    public interface IQueue
    {
        void Enqueue(int[] data);
        void Dequeue(int itensAmount);
        int GetFirst();
        int GetLast();
        bool IsEmpty();
    }
    public class Queue : IQueue
    {
        private int Capacity { get; set; }
        private int StartIdx { get; set; }
        private int DataLenght { get; set; }
        public int?[] QueueData { get; set; }

        public Queue(int capacity)
        {
            Capacity = capacity;
            StartIdx = 0;
            DataLenght = 0;
        }

        public void Enqueue(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                DataLenght++;
                int index = (StartIdx + DataLenght) % Capacity;
                if (index <= Capacity)
                    QueueData[index] = data[i];

                StartIdx++;
            }
        }

        public void Dequeue(int itensAmount)
        {
            while(itensAmount > 0)
            {
                QueueData[StartIdx] = null;
                StartIdx = (StartIdx + 1) % Capacity;
                DataLenght--;
                itensAmount--;
            }
            StartIdx = 0;
        }

        public int GetFirst() => QueueData[StartIdx].Value;

        public int GetLast() => QueueData[DataLenght].Value;

        public bool IsEmpty() => DataLenght == StartIdx && StartIdx == 0;
        
    }
}
