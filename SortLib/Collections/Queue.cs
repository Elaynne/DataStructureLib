using SortLib.Interface;

namespace SortLib.Collections
{
    public class Queue<T> : IQueue<T>
    {
        private int Capacity { get; set; }
        private int Start { get; set; }
        private int lenght = 0;
        public int Count { get => lenght;  }
        private T[] QueueData { get; set; }

        public Queue(int capacity)
        {
            Capacity = capacity;
            Start = 0;
            lenght = 0;
            QueueData = new T[capacity];
        }

        public void Enqueue(T data)
        {

            int index = (Start + Count) % Capacity;
            if (index <= Capacity - 1)
                QueueData[index] = data;
            lenght++;
        }
        
        public T Dequeue()
        {
            if (IsEmpty())
                throw new System.ArgumentException("The queue is empty and has nothing to dequeue.");
           
            T aux = QueueData[Start];
            Start = (Start + 1) % Capacity;
            lenght--;
            return aux;
        }

        public T GetFirst() => QueueData[Start];

        public T GetLast() => QueueData[Count - 1];

        public bool IsEmpty() => Count == 0;

        public int GetStartIdx() => Start;

        public T[] GetQueue()
        {
            T[] data = new T[lenght];
            int idx = 0;
            for (int i = Start; i < Capacity; i++)
            {
                data[idx] = QueueData[i];
                idx++;
            }
            return data;
        }
    }
}
