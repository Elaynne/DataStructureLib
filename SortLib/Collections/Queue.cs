using SortLib.Interface;

namespace SortLib.Collections
{
    public class Queue : IQueue
    {
        private int Capacity { get; set; }
        private int Start { get; set; }
        private int Lenght { get; set; }
        private int[] QueueData { get; set; }

        public Queue(int capacity)
        {
            Capacity = capacity;
            Start = 0;
            Lenght = 0;
            QueueData = new int[capacity];
        }

        public void Enqueue(int data)
        {

            int index = (Start + Lenght) % Capacity;
            if (index <= Capacity - 1)
                QueueData[index] = data;
            Lenght++;
        }
        
        public int Dequeue()
        {
            if (IsEmpty())
                throw new System.ArgumentException("The queue is empty and has nothing to dequeue.");
           
            int aux = QueueData[Start];
            Start = (Start + 1) % Capacity;
            Lenght--;
            return aux;
        }

        public int GetFirst() => QueueData[Start];

        public int GetLast() => QueueData[Lenght-1];

        public bool IsEmpty() => Lenght == 0;

        public int GetLenght() => Lenght;

        public int GetStartIdx() => Start;
        
        public int[] GetQueue()
        {
            return QueueData;
        }
    }
}
