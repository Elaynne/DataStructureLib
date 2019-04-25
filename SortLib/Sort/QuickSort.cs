using System;

namespace SortLib.Sort
{
    public class QuickSort<T>
    {
        private DSUtil Util { get; set; }
        public string QSLog { get; private set; }

        public QuickSort()
        {
            Util = new DSUtil();
        }

        public string QuickSortTime(T[] data, int ini, int fim)
        {
            DateTime start = DateTime.Now;
            Quicksort(data, ini, fim);
            DateTime end = DateTime.Now;
            QSLog = (end - start).ToString();
            return QSLog;
        }

        public void Quicksort(T[] data, int ini, int fim)
        {
            if (ini < fim)
            {
                T pivo = data[ini];
                int i = ini + 1;
                int j = fim;

                while (i <= j)
                {
                    if (Util.ValidateLessEqual(data[i], pivo)) i++;
                    
                    else if (Util.ValidateLess( pivo, pivo, data[j])) j--;
                    
                    else
                    {
                        T troca = data[i];
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
