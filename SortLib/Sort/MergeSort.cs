using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SortLib.Sort
{
    
    public class EstruturaCodigo
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
    }

    public class MergeSort
    {
        static int cont = 0;
        static string file;

        public static void Mergesort(EstruturaCodigo[] inputArgs, EstruturaCodigo[] outputArgs, int init, int end)
        {
            string myStr = string.Empty;

            if (init < end)
            {
                int mid = init + ((end - init) / 2);

                Mergesort(inputArgs, outputArgs, init, mid);
                Mergesort(inputArgs, outputArgs, mid + 1, end);
                Interpolate(inputArgs, outputArgs, init, end);
                try
                {
                    myStr = cont + ": ";

                    for (int i = 0; i < inputArgs.Length; i++)
                    {
                        myStr += i != (inputArgs.Length - 1) ? inputArgs[i].GetString() + " " : inputArgs[i].GetString();
                        myStr += Environment.NewLine;
                    }
                    cont++;

                    File.WriteAllText(@"C:\Users\Elaynne\Documents\SortFiles\MergeSort.txt", myStr);
                }
                catch (IOException e) { }
            }
        }

        public static void Interpolate(EstruturaCodigo[] inputArgs, EstruturaCodigo[] outputArgs, int init, int end)
        {
            int i = init;
            int mid = init + ((end - init) / 2);
            int j = mid + 1;
            int k = init;
            while (i <= mid && j <= end)
            {
                if (string.Compare(inputArgs[i].OwnerCod, inputArgs[j].OwnerCod) < 0)
                {
                    outputArgs[k] = inputArgs[i];
                    k++;
                    i++;
                }
                else if (string.Compare(inputArgs[i].OwnerCod, inputArgs[j].OwnerCod) == 0)
                {
                    if (inputArgs[i].Priori >= inputArgs[j].Priori)
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
