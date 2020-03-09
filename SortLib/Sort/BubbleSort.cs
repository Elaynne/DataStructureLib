using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortLib.Sort
{
    public class BubbleSort<T>
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
            switch (elements)
            {
                case int[] i:
                    return BubbleInteger(elements.Select(x => Convert.ToInt32(x)).ToArray()) as T[];
                case string[] str:
                    //todo
                    throw new NotImplementedException("TODO");
                default:
                    throw new ArgumentException("I can't handle the type of your values.");
            }
        }

        private int[] BubbleInteger(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (elements[j] > elements[j + 1])
                    {
                        int buffer = elements[j + 1];
                        elements[j + 1] = elements[j];
                        elements[j] = buffer;
                    }
                }
            }
            return elements;
        }
    }
}
