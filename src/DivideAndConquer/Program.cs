using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DivideAndConquer
{
    internal class Program
    {
        private static Random random = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static IReadOnlyList<int> smallList;
        private static IReadOnlyList<int> mediumList;
        private static IReadOnlyList<int> largeList;

        private static void Main(string[] args)
        {
            Initialize();

            Console.WriteLine("Unsorted small list: " + string.Join(", ", smallList));
            Console.WriteLine();
            SortTest(new List<int>(smallList), BubbleSort, "Small list BubbleSort", true);
            SortTest(new List<int>(smallList), QuickSort, "Small list QuickSort", true);
            SortTest(new List<int>(smallList), MergeSort, "Small list MergeSort", true);

            SortTest(new List<int>(mediumList), BubbleSort, "Medium list BubbleSort", false);
            SortTest(new List<int>(mediumList), QuickSort, "Medium list QuickSort", false);
            SortTest(new List<int>(mediumList), MergeSort, "Medium list MergeSort", false);

            //SortTest(new List<int>(largeList), BubbleSort, "Large list BubbleSort", false);
            SortTest(new List<int>(largeList), QuickSort, "Large list QuickSort", false);
            SortTest(new List<int>(largeList), MergeSort, "Large list MergeSort", false);
        }

        private static void SortTest<T>(IList<T> list, Action<IList<T>> sort, string message, bool showResults)
        {
            Console.WriteLine("Beginning " + message + " test...");
            stopwatch.Restart();
            sort(list);
            stopwatch.Stop();
            if (showResults)
                Console.WriteLine("Results: " + string.Join(", ", list));

            Console.WriteLine(message + " elapsed time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine();
        }

        private static void BubbleSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.BubbleSort();
        }

        private static void QuickSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.QuickSort();
        }

        private static void MergeSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.MergeSort();
        }

        private static void Initialize()
        {
            int small = 10;
            int medium = 1000;
            int large = 100000;

            List<int> list1 = new List<int>(small);
            for (int i = 0; i < small; i++)
            {
                list1.Add(random.Next(small));
            }
            smallList = list1;

            List<int> list2 = new List<int>(medium);
            for (int i = 0; i < medium; i++)
            {
                list2.Add(random.Next(large));
            }
            mediumList = list2;

            List<int> list3 = new List<int>(large);
            for (int i = 0; i < large; i++)
            {
                list3.Add(random.Next(large));
            }
            largeList = list3;
        }

        /*

        private static void BubbleSort<T>(IList<T> list)
            where T : IComparable<T>
        {
            list.BubbleSort();
        }

        private static void QuickSortTest1()
        {
            List<int> list = new List<int>(smallIntList);
            WriteList(list);

            stopwatch.Restart();
            list.QuickSort();
            stopwatch.Stop();

            WriteList(list);
            Console.WriteLine("QuickSort (Small) Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void MergeSortTest1()
        {
            List<int> list = new List<int>(smallIntList);
            WriteList(list);

            stopwatch.Restart();
            list.MergeSort();
            stopwatch.Stop();

            WriteList(list);
            Console.WriteLine("MergeSort (Small) Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void QuickSortTest2()
        {
            List<int> list = new List<int>(bigIntList);

            stopwatch.Restart();
            list.QuickSort();
            stopwatch.Stop();

            //WriteList(list);
            Console.WriteLine("QuickSort (Large) Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void MergeSortTest2()
        {
            List<int> list = new List<int>(bigIntList);

            stopwatch.Restart();
            list.MergeSort();
            stopwatch.Stop();
            
            //WriteList(list);
            Console.WriteLine("MergeSort (Large) Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }
        */

        private static void WriteList<T>(IList<T> list)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}
