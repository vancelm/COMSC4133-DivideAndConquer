/*******************************************************************************
* Student: Vance Morgan
* Instructor: Dr. Evert
* Course: COMSC-4133.1410 Design/Analysis Comp Algorithms
* Semester: Summer 2021
* Assignment: Divide and Conquer
*******************************************************************************/

using System;
using System.Collections.Generic;

namespace DivideAndConquer
{
    /// <summary>
    /// Provides various sorting extension methods to lists.
    /// </summary>
    public static class ListExtensions
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Swaps two elements within a list at the given indexes.
        /// </summary>
        /// <param name="list">The list containing the elements to swap.</param>
        /// <param name="index1">The index of the first element.</param>
        /// <param name="index2">The index of the second element.</param>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        private static void Swap<T>(this IList<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        /// <summary>
        /// Sorts a list using the bubble sort algorithm.
        /// </summary>
        /// <param name="list">The list containing elements to be sorted.</param>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
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

        /// <summary>
        /// Sorts a list using a recursive quick sort algorithm.
        /// </summary>
        /// <param name="list">The list containing elements to be sorted.</param>
        /// <param name="randomPivot">Specifies whether the quick sort pivot should be randomized.</param>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        public static void QuickSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            QuickSort_Recursive(list, 0, list.Count - 1);
        }

        private static void QuickSort_Recursive<T>(IList<T> list, int low, int high)
            where T : IComparable<T>
        {
            if (low >= high)
            {
                return;
            }

            int partition = QuickSort_Partition(list, low, high);
            QuickSort_Recursive(list, low, partition);
            QuickSort_Recursive(list, partition + 1, high);
        }

        private static int QuickSort_Partition<T>(IList<T> list, int low, int high)
            where T : IComparable<T>
        {
            list.Swap(random.Next(low, high), low);

            T pivot = list[low];
            int i = low - 1;
            int j = high + 1;

            while (true)
            {
                do
                {
                    i++;
                }
                while (list[i].CompareTo(pivot) < 0);

                do
                {
                    j--;
                }
                while (list[j].CompareTo(pivot) > 0);

                if (i >= j)
                {
                    return j;
                }

                list.Swap(i, j);
            }
        }

        /// <summary>
        /// Sorts a list using a recursive merge sort algorithm.
        /// </summary>
        /// <param name="list">The list containing elements to be sorted.</param>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        public static void MergeSort<T>(this IList<T> list)
            where T : IComparable<T>
        {
            T[] tempArray = new T[list.Count];
            MergeSort_Recursive(list, tempArray, 0, list.Count - 1);
        }

        private static void MergeSort_Recursive<T>(IList<T> list, T[] tempArray, int left, int right)
            where T : IComparable<T>
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort_Recursive(list, tempArray, left, middle);
                MergeSort_Recursive(list, tempArray, middle + 1, right);
                MergeSort_Merge(list, tempArray, left, middle, right);
            }
        }

        private static void MergeSort_Merge<T>(IList<T> list, T[] tempArray, int left, int middle, int right)
            where T : IComparable<T>
        {
            int leftLength = middle - left + 1;
            int rightLength = right - middle;

            int i;
            int j;

            for (i = 0; i < leftLength; i++)
            {
                tempArray[i] = list[left + i];
            }

            for (j = 0; j < rightLength; j++)
            {
                tempArray[middle + 1 + j] = list[middle + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;

            while (i < leftLength && j < rightLength)
            {
                if (tempArray[i].CompareTo(tempArray[middle + 1 + j]) <= 0)
                {
                    list[k] = tempArray[i];
                    i++;
                }
                else
                {
                    list[k] = tempArray[middle + 1 + j];
                    j++;
                }

                k++;
            }

            while (i < leftLength)
            {
                list[k] = tempArray[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                list[k] = tempArray[middle + 1 + j];
                j++;
                k++;
            }
        }
    }
}