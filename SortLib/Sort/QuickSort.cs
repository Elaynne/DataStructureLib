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

        public string QuickSortTime(T[] data, int ini, int end)
        {
            DateTime start = DateTime.Now;
            Quicksort(data, ini, end);
            DateTime endTime = DateTime.Now;
            QSLog = (endTime - start).ToString();
            return QSLog;
        }

        public void Quicksort(T[] data, int ini, int end)
        {
            if (ini < end)
            {
                T pivo = data[ini];
                int i = ini + 1;
                int j = end;

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
                Quicksort(data, j + 1, end);
            }
        }
    }
}
