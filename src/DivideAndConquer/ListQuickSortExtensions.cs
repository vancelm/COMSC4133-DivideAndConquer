using System;
using System.Collections.Generic;
using System.Linq;

namespace DivideAndConquer
{
    public static class ListQuickSortExtensions
    {       
        public static void QuickSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            Sort(list, 0, list.Count - 1);
        }

        private static void Sort<T>(IList<T> list, int low, int high)
            where T : IComparable<T>
        {
            if (low < high)
            {
                int partition = Partition(list, low, high);

                Sort(list, low, partition - 1);
                Sort(list, partition + 1, high);
            }
        }

        private static int Partition<T>(IList<T> list, int low, int high)
            where T : IComparable<T>
        {
            T pivot = list[high];

            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (list[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, high);
            return i + 1;
        }
        private static void Swap<T>(IList<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}