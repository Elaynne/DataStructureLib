using SortLib.Interface;
using System;
using System.Text;

namespace SortLib.Sort
{
    public class MergeSort<T>
    {
        public string MSlog { get;set; }
        int cont = 0;
        private DSUtil Util { get; set; }

        public MergeSort()
        {
            Util = new DSUtil();
        }

        public void SortTime(T[] inputArgs, int init, int end)
        {
            DateTime startTime = DateTime.Now;
            Sort(inputArgs, init, end);
            DateTime endtime = DateTime.Now;
            MSlog = (endtime - startTime).ToString();
        }

        public void Sort(T[] inputArgs, int init, int end)
        {
            StringBuilder steps = new StringBuilder("");

            if (init < end)
            {
                int mid = init + ((end - init) / 2);

                Sort(inputArgs, init, mid);
                Sort(inputArgs, mid + 1, end);
                Merge(inputArgs, init, mid, end);
                
                steps.Append(cont + ": ");

                //STEPS
                for (int i = 0; i < inputArgs.Length; i++) {
                    steps.Append(value: i != (inputArgs.Length - 1) ? inputArgs[i].ToString() + " " : inputArgs[i].ToString());
                }

                cont++;
                Console.WriteLine(steps);
            }
        }

        private void Merge(T[] inputArgs, int init, int mid, int end)
        {
            //left side of the array
            int i = init;
            //right side of the array
            int j = mid + 1;
            //the output index
            int k = init;
            T[] outputArgs = new T[inputArgs.Length];

            while (i <= mid && j <= end)
            {
                if (Util.ValidateLessEqual(inputArgs[i], inputArgs[j]))
                {
                    outputArgs[k] = inputArgs[i];
                    i++;
                }
                else
                {
                    outputArgs[k] = inputArgs[j];
                    j++;
                }
                k++;
            }
            if (i <= mid)
            {
                for (int i2 = i; i2 <= mid; i2++)
                {
                    outputArgs[k] = inputArgs[i2];
                    k++;
                }
            }
            if (j <= end)
            { 
                for (int j2 = j; j2 <= end; j2++)
                {
                    outputArgs[k] = inputArgs[j2];
                    k++;
                }
            }
           for (int ij = init; ij <= end; ij++)
               inputArgs[ij] = outputArgs[ij];
        }
    }   
}
