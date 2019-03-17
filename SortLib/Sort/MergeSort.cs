using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SortLib.Sort
{
    
    /*public class EstruturaCodigo
    {
        public Int16 Priori { get; set; }
        public string LoadCod { get; set; }
        public string Input { get; set; }
        public string OwnerCod { get; set; }

        public EstruturaCodigo(string input)
        {
            Priori = Convert.ToInt16(input.Substring(input.Length - 1, input.Length));
            //Console.Writeline(Priori);
            LoadCod = input.Substring(5, 10);
            //Console.WriteLine(LoadCod);
            OwnerCod = input.Substring(2, 5);
            //Console.WriteLine(Priori);
            Input = input;
        }

        public string GetString()
        {
            return OwnerCod + LoadCod;
        }
    }*/

    public class MergeSort
    {
        static int cont = 0;

        public void Mergesort(int[] inputArgs, int init, int end)
        {

            string steps = string.Empty;
            
            if (init < end)
            {
                int mid = init + ((end - init) / 2);

                Mergesort(inputArgs, init, mid);
                Mergesort(inputArgs, mid + 1, end);
                Interpolate(inputArgs, init, mid, end);
                // try
                // {
                steps = cont + ": ";

                //STEPS
                    for (int i = 0; i < inputArgs.Length; i++)
                    steps += i != (inputArgs.Length - 1) ? inputArgs[i].ToString() + " " : inputArgs[i].ToString();

                steps += Environment.NewLine;
                cont++;
                Console.WriteLine(steps);
                
               
                //File.WriteAllText(@"C:\Users\Elaynne\Documents\SortFiles\MergeSort.txt", myStr);
               // }
               // catch (IOException e) { }
            }
        }

        public static void Interpolate(int[] inputArgs, int init, int mid, int end)
        {
            int i = init;
            int j = mid + 1;
            int k = init;
            int[] outputArgs = new int[inputArgs.Length];

            while (i <= mid && j <= end)
            {
                if (inputArgs[i] <= inputArgs[j])
                {
                    outputArgs[k] = inputArgs[i];
                    k++;
                    i++;
                }
                else
                {
                    outputArgs[k] = inputArgs[j];
                    k++;
                    j++;
                }
            }

            if (i <= mid)
                for (int i2 = i; i2 <= mid; i2++)
                {
                    outputArgs[k] = inputArgs[i2];
                    k++;
                }

            if (j <= end)
                for (int j2 = j; j2 <= end; j2++)
                {
                    outputArgs[k] = inputArgs[j2];
                    k++;
                }

            for (int ij = init; ij <= end; ij++)
                inputArgs[ij] = outputArgs[ij];
        }
    }   
}
