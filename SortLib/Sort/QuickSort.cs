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

        public void SortTime(T[] data, int ini, int end)
        {
            DateTime start = DateTime.Now;
            Sort(data, ini, end);
            DateTime endTime = DateTime.Now;
            QSLog = (endTime - start).ToString();
        }

        public void Sort(T[] data, int ini, int end)
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
                Sort(data, ini, j - 1);
                Sort(data, j + 1, end);
            }
        }
    }
}
