using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DivideAndConquer
{
    internal class Program
    {
        private static Random random = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static List<int> smallIntList;
        private static List<int> bigIntList;

        private static void Main(string[] args)
        {
            Initialize();
            QuickSortTest1();
            QuickSortTest2();
        }
        private static void Initialize()
        {
            smallIntList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                smallIntList.Add(random.Next(100));
            }

            bigIntList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                bigIntList.Add(random.Next(10000));
            }
        }

        private static void QuickSortTest1()
        {
            List<int> list = new List<int>(smallIntList);
            Console.WriteLine("Beginning QuickSort Small Test");
            stopwatch.Start();
            list.QuickSort();
            stopwatch.Stop();
            WriteList(list);
            Console.WriteLine("Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void QuickSortTest2()
        {
            List<int> list = new List<int>(bigIntList);
            Console.WriteLine("Beginning QuickSort Big Test");
            stopwatch.Start();
            list.QuickSort();
            stopwatch.Stop();
            WriteList(list);
            Console.WriteLine("Elapsed Time (ms): " + stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void WriteList<T>(IList<T> list)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}
