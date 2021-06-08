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

        private static void Sort<T>(IList<T> list, int lowIndex, int highIndex)
            where T : IComparable<T>
        {
            if (lowIndex < highIndex)
            {
                int partitionIndex = Partition(list, lowIndex, highIndex);

                Sort(list, lowIndex, partitionIndex - 1);
                Sort(list, partitionIndex + 1, highIndex);
            }
        }

        private static int Partition<T>(IList<T> list, int lowIndex, int highIndex)
            where T : IComparable<T>
        {
            T pivot = list[highIndex];

            int i = lowIndex - 1;

            for (int j = lowIndex; j <= highIndex - 1; j++)
            {
                if (list[j].CompareTo(pivot) < 0)
                {
                    i++;
                    list.Swap(i, j);
                }
            }

            list.Swap(i + 1, highIndex);
            return i + 1;
        }
    }
}