using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DivideAndConquer
{
    internal class Program
    {
        private static Random random = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static IReadOnlyList<int> smallRandomList;
        private static IReadOnlyList<int> mediumRandomList;
        private static IReadOnlyList<int> largeRandomList;

        private static IReadOnlyList<int> smallSequentialList;
        private static IReadOnlyList<int> mediumSequentialList;
        private static IReadOnlyList<int> largeSequentialList;

        private static IReadOnlyList<int> smallReverseList;
        private static IReadOnlyList<int> mediumReverseList;
        private static IReadOnlyList<int> largeReverseList;

        private static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                Initialize();

                Console.WriteLine("Small random list: " + string.Join(", ", smallRandomList));
                Console.WriteLine();

                sb.Append(SortTest(new List<int>(smallRandomList), BubbleSort, true, nameof(smallRandomList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(smallRandomList), QuickSort, true, nameof(smallRandomList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(smallRandomList), QuickSortRandom, true, nameof(smallRandomList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(smallRandomList), MergeSort, true, nameof(smallRandomList), nameof(MergeSort)) + ",");

                sb.Append(SortTest(new List<int>(mediumRandomList), BubbleSort, false, nameof(mediumRandomList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(mediumRandomList), QuickSort, false, nameof(mediumRandomList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(mediumRandomList), QuickSortRandom, false, nameof(mediumRandomList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(mediumRandomList), MergeSort, false, nameof(mediumRandomList), nameof(MergeSort)) + ",");

                sb.Append(SortTest(new List<int>(largeRandomList), BubbleSort, false, nameof(largeRandomList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(largeRandomList), QuickSort, false, nameof(largeRandomList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(largeRandomList), QuickSortRandom, false, nameof(largeRandomList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(largeRandomList), MergeSort, false, nameof(largeRandomList), nameof(MergeSort)) + ",");

                Console.WriteLine();
                Console.WriteLine("----------");
                Console.WriteLine("Small sequential list: " + string.Join(", ", smallSequentialList));
                Console.WriteLine();
                sb.Append(SortTest(new List<int>(smallSequentialList), BubbleSort, true, nameof(smallSequentialList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(smallSequentialList), QuickSort, true, nameof(smallSequentialList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(smallSequentialList), QuickSortRandom, true, nameof(smallSequentialList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(smallSequentialList), MergeSort, true, nameof(smallSequentialList), nameof(MergeSort)) + ",");

                sb.Append(SortTest(new List<int>(mediumSequentialList), BubbleSort, false, nameof(mediumSequentialList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(mediumSequentialList), QuickSort, false, nameof(mediumSequentialList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(mediumSequentialList), QuickSortRandom, false, nameof(mediumSequentialList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(mediumSequentialList), MergeSort, false, nameof(mediumSequentialList), nameof(MergeSort)) + ",");

                sb.Append(SortTest(new List<int>(largeSequentialList), BubbleSort, false, nameof(largeSequentialList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(largeSequentialList), QuickSort, false, nameof(largeSequentialList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(largeSequentialList), QuickSortRandom, false, nameof(largeSequentialList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(largeSequentialList), MergeSort, false, nameof(largeSequentialList), nameof(MergeSort)) + ",");


                Console.WriteLine();
                Console.WriteLine("----------");
                Console.WriteLine("Small reverse list: " + string.Join(", ", smallReverseList));
                Console.WriteLine();
                sb.Append(SortTest(new List<int>(smallReverseList), BubbleSort, true, nameof(smallReverseList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(smallReverseList), QuickSort, true, nameof(smallReverseList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(smallReverseList), QuickSortRandom, true, nameof(smallReverseList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(smallReverseList), MergeSort, true, nameof(smallReverseList), nameof(MergeSort)) + ",");

                sb.Append(SortTest(new List<int>(mediumReverseList), BubbleSort, false, nameof(mediumReverseList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(mediumReverseList), QuickSort, false, nameof(mediumReverseList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(mediumReverseList), QuickSortRandom, false, nameof(mediumReverseList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(mediumReverseList), MergeSort, false, nameof(mediumReverseList), nameof(MergeSort)) + ",");

                sb.Append(SortTest(new List<int>(largeReverseList), BubbleSort, false, nameof(largeReverseList), nameof(BubbleSort)) + ",");
                sb.Append(SortTest(new List<int>(largeReverseList), QuickSort, false, nameof(largeReverseList), nameof(QuickSort)) + ",");
                sb.Append(SortTest(new List<int>(largeReverseList), QuickSortRandom, false, nameof(largeReverseList), nameof(QuickSortRandom)) + ",");
                sb.Append(SortTest(new List<int>(largeReverseList), MergeSort, false, nameof(largeReverseList), nameof(MergeSort)) + "\r\n");
            }
            Console.WriteLine(sb.ToString());
        }

        private static double SortTest<T>(IList<T> list, Action<IList<T>> sort, bool showResults, string listName, string algorithmName)
        {
            stopwatch.Restart();
            sort(list);
            stopwatch.Stop();
            if (showResults)
                Console.WriteLine("Results: " + string.Join(", ", list));

            Console.WriteLine("{0} {1} elapsed time: {2}ms", listName, algorithmName, stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        private static void BubbleSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.BubbleSort();
        }

        private static void QuickSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.QuickSort(false);
        }

        private static void QuickSortRandom<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.QuickSort(true);
        }

        private static void MergeSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.MergeSort();
        }

        private static void Sort<T>(IList<T> list)
        {
            ((List<T>)list).Sort();
        }

        private static void Initialize()
        {
            int small = 10;
            int medium = 1000;
            int large = 10000;

            smallRandomList = GetRandomIntList(small);
            smallSequentialList = GetSequentialList(small);
            smallReverseList = GetReverseList(small);

            mediumRandomList = GetRandomIntList(medium);
            mediumSequentialList = GetSequentialList(medium);
            mediumReverseList = GetReverseList(medium);

            largeRandomList = GetRandomIntList(large);
            largeSequentialList = GetSequentialList(large);
            largeReverseList = GetReverseList(large);
        }

        private static List<int> GetRandomIntList(int count)
        {
            List<int> list = new List<int>(count);
            for (int i = 0; i < count; i++)
                list.Add(random.Next(count));
            return list;
        }

        private static List<int> GetSequentialList(int count)
        {
            List<int> list = new List<int>(count);
            for (int i = 0; i < count; i++)
                list.Add(i);
            return list;
        }
        private static List<int> GetReverseList(int count)
        {
            List<int> list = new List<int>(count);
            for (int i = count; i >= 0; i--)
                list.Add(i);
            return list;
        }
    }
}
