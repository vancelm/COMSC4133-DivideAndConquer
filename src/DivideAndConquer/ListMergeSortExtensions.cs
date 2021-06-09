using System;
using System.Collections.Generic;

namespace DivideAndConquer
{
    public static class ListMergeSortExtensions
    {
        public static void MergeSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            Sort(list, 0, list.Count - 1);
        }

        private static void Sort<T>(IList<T> list, int left, int right)
            where T : IComparable<T>
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                Sort(list, left, middle);
                Sort(list, middle + 1, right);
                Merge(list, left, middle, right);
            }
        }

        private static void Merge<T>(IList<T> list, int left, int middle, int right)
            where T : IComparable<T>
        {
            T[] leftList = new T[middle - left + 1];
            T[] rightList = new T[right - middle];
            int i, j;

            for (i = 0; i < leftList.Length; i++)
                leftList[i] = list[left + i];

            for (j = 0; j < rightList.Length; j++)
                rightList[j] = list[middle + 1 + j];

            i = 0;
            j = 0;

            int k = left;
            while (i < leftList.Length && j < rightList.Length)
            {
                if (leftList[i].CompareTo(rightList[j]) <= 0)
                {
                    list[k] = leftList[i];
                    i++;
                }
                else {
                    list[k] = rightList[j];
                    j++;
                }

                k++;
            }

            while (i < leftList.Length)
            {
                list[k] = leftList[i];
                i++;
                k++;
            }

            while (j < rightList.Length)
            {
                list[k] = rightList[j];
                j++;
                k++;
            }
        }
        
    }
}