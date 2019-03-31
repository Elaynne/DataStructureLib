﻿

namespace SortLib.Sort
{
    public class QuickSort
    {
        public void Quicksort(int[] data, int ini, int fim)
        {
            if (ini < fim)
            {
                int pivo = data[ini];
                int i = ini + 1;
                int j = fim;

                while (i <= j)
                {
                    if (data[i] <= pivo) i++;
                    
                    else if (pivo < data[j]) j--;
                    
                    else
                    {
                        int troca = data[i];
                        data[i] = data[j];
                        data[j] = troca;
                        i++;
                        j--;
                    }
                }
                data[ini] = data[j];
                data[j] = pivo;
                Quicksort(data, ini, j - 1);
                Quicksort(data, j + 1, fim);
            }

        }
    }
}
