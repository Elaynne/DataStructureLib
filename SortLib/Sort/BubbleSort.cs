using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortLib.Sort
{
    public class BubbleSort<T> where T: IComparable
    {
        public string Duration { get; private set; }
        public void SortTime(T[] myInput)
        {
            DateTime start = DateTime.Now;
            Sort(myInput);
            DateTime end = DateTime.Now;
            Duration = (end - start).ToString();
        }
        public T[] Sort(T[] elements) 
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (elements[j].CompareTo(elements[j + 1]) > 0)
                    {
                        T buffer = elements[j + 1];
                        elements[j + 1] = elements[j];
                        elements[j] = buffer;
                    }
                }
            }

            return elements;
        }
    }
}
