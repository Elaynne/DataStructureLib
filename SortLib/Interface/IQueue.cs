using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib.Interface
{
    public interface IQueue
    {
        /// <summary>
        /// Insert an element on the queue if it is not full yet
        /// </summary>
        /// <param name="data"></param>
        void Enqueue(int data);

        /// <summary>
        /// If return null, the queue is empty and is not possible to dequeue
        /// </summary>
        /// <returns></returns>
        int Dequeue();

        /// <summary>
        /// Return the current first element
        /// </summary>
        /// <returns></returns>
        int GetFirst();

        /// <summary>
        /// Return the last element of the queue
        /// </summary>
        /// <returns></returns>
        int GetLast();

        /// <summary>
        /// If it's true, the queue is empty
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Return the amount of itens on queue
        /// </summary>
        /// <returns></returns>
        int GetLenght();

        /// <summary>
        /// Return the current starter index of the queue
        /// </summary>
        /// <returns></returns>
        int GetStartIdx();
    }
}
