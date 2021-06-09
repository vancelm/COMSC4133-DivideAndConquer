using System;
using System.Collections.Generic;

namespace DivideAndConquer
{
    public static class ListQuickSortExtensions
    {
        private static void Swap<T>(this IList<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static void BubbleSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        list.Swap(j, j + 1);
                    }
                }
            }
        }

        public static void QuickSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            QuickSort(list, 0, list.Count - 1);
        }

        private static void QuickSort<T>(IList<T> list, int low, int high)
            where T : IComparable<T>
        {
            if (low < high)
            {
                int partition = Partition(list, low, high);

                QuickSort(list, low, partition - 1);
                QuickSort(list, partition + 1, high);
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
                    list.Swap(i, j);
                }
            }

            list.Swap(i + 1, high);
            return i + 1;
        }

        public static void MergeSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            T[] temp = new T[list.Count];
            MergeSort(list, temp, 0, list.Count - 1);
        }

        private static void MergeSort<T>(IList<T> list, T[] temp, int left, int right)
            where T : IComparable<T>
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(list, temp, left, middle);
                MergeSort(list, temp, middle + 1, right);
                Merge(list, temp, left, middle, right);
            }
        }

        private static void Merge<T>(IList<T> list, T[] temp, int left, int middle, int right)
            where T : IComparable<T>
        {
            int leftLength = middle - left + 1;
            int rightLength = right - middle;

            int i, j;

            for (i = 0; i < leftLength; i++)
                temp[i] = list[left + i];

            for (j = 0; j < rightLength; j++)
                temp[j + 1 + middle] = list[middle + 1 + j];

            i = 0;
            j = 0;

            int k = left;
            while (i < leftLength && j < rightLength)
            {
                if (temp[i].CompareTo(temp[j + 1 + middle]) <= 0)
                {
                    list[k] = temp[i];
                    i++;
                }
                else
                {
                    list[k] = temp[j + 1 + middle];
                    j++;
                }

                k++;
            }

            while (i < leftLength)
            {
                list[k] = temp[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                list[k] = temp[j + 1 + middle];
                j++;
                k++;
            }
        }
    }
}