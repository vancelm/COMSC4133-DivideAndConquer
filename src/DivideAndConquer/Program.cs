using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DivideAndConquer
{
    internal class Program
    {
        private static Random random = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static IList<int> smallIntList;
        private static List<int> bigIntList;

        private static void Main(string[] args)
        {
            Initialize();
            QuickSortTest1();
            QuickSortTest2();
            MergeSortTest1();
            MergeSortTest2();
            
        }
        private static void Initialize()
        {
            List<int> list1 = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list1.Add(random.Next(100));
            }
            smallIntList = list1;

            List<int> list2 = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                list2.Add(random.Next(100));
            }
            bigIntList = list2;
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

        private static void QuickSortTest2()
        {
            List<int> list = new List<int>(bigIntList);

            stopwatch.Restart();
            list.QuickSort();
            stopwatch.Stop();

            //WriteList(list);
            Console.WriteLine("QuickSort (Large) Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
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

        private static void MergeSortTest2()
        {
            List<int> list = new List<int>(bigIntList);

            stopwatch.Restart();
            list.MergeSort();
            stopwatch.Stop();
            
            //WriteList(list);
            Console.WriteLine("MergeSort (Large) Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void WriteList<T>(IList<T> list)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}
