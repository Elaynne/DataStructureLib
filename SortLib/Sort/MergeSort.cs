using System;
using System.Text;

namespace SortLib.Sort
{
    public class MergeSort
    {
        int cont = 0;

        public void Mergesort(int[] inputArgs, int init, int end)
        {
            StringBuilder steps = new StringBuilder("");

            if (init < end)
            {
                int mid = init + ((end - init) / 2);

                Mergesort(inputArgs, init, mid);
                Mergesort(inputArgs, mid + 1, end);
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

        private static void Merge(int[] inputArgs, int init, int mid, int end)
        {
            //left side of the array
            int i = init;
            //right side of the array
            int j = mid + 1;
            //the output index
            int k = init;
            int[] outputArgs = new int[inputArgs.Length];

            while (i <= mid && j <= end)
            {
                if (inputArgs[i] <= inputArgs[j])
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

            if (i <= mid) {
                
                for (int i2 = i; i2 <= mid; i2++)
                {
                    outputArgs[k] = inputArgs[i2];
                    k++;
                }
            }
            if (j <= end) { 
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
