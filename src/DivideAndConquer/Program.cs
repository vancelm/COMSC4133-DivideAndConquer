using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DivideAndConquer
{
    internal class Program
    {
        private static readonly Random random = new Random();
        private static readonly Stopwatch stopwatch = new Stopwatch();

        private static void Main(string[] args)
        {
            Validate();
            RunTests();
        }

        private static void Validate()
        {
            List<int> unsortedList = GetRandomList(20);
            List<int> sortedList = new List<int>(unsortedList);
            sortedList.Sort(); // Assuming the built-in sort works ;)

            Console.WriteLine("Unsorted: " + string.Join(",", unsortedList));
            Console.WriteLine("Sorted: " + string.Join(",", sortedList));
            ValidateList(sortedList, new List<int>(unsortedList), BubbleSort, nameof(BubbleSort));
            ValidateList(sortedList, new List<int>(unsortedList), BubbleSort, nameof(QuickSort));
            ValidateList(sortedList, new List<int>(unsortedList), BubbleSort, nameof(QuickSortRandom));
            ValidateList(sortedList, new List<int>(unsortedList), BubbleSort, nameof(MergeSort));
        }

        private static void ValidateList<T>(IList<T> sortedList, IList<T> list, Action<IList<T>> sort, string name)
        {
            sort(list);
            Console.Write(name + ": " + string.Join(",", list));
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Equals(sortedList[i]))
                {
                    Console.WriteLine(" <FAIL>");
                    break;
                }
            }

            Console.WriteLine(" <PASS>");
        }

        private static void RunTests()
        {
            int min = 500;
            int max = 10000;
            int increment = 500;
            IList<int> list;

            Console.WriteLine();
            Console.WriteLine("Random");
            Console.WriteLine("Size,Bubble,Quick,Quick Random,Merge,Framework");
            for (int i = min; i <= max; i += increment)
            {
                list = GetRandomList(i);
                Console.Write(i + ",");
                Console.Write(SortTest(new List<int>(list), BubbleSort) + ",");
                Console.Write(SortTest(new List<int>(list), QuickSort) + ",");
                Console.Write(SortTest(new List<int>(list), QuickSortRandom) + ",");
                Console.Write(SortTest(new List<int>(list), MergeSort) + ",");
                Console.Write(SortTest(new List<int>(list), Sort) + "\r\n");
            }

            Console.WriteLine();
            Console.WriteLine("Sequential");
            Console.WriteLine("Size,Bubble,Quick,Quick Random,Merge,Framework");
            for (int i = min; i <= max; i += increment)
            {
                list = GetSequentialList(i);
                Console.Write(i + ",");
                Console.Write(SortTest(new List<int>(list), BubbleSort) + ",");
                Console.Write(SortTest(new List<int>(list), QuickSort) + ",");
                Console.Write(SortTest(new List<int>(list), QuickSortRandom) + ",");
                Console.Write(SortTest(new List<int>(list), MergeSort) + ",");
                Console.Write(SortTest(new List<int>(list), Sort) + "\r\n");
            }

            Console.WriteLine();
            Console.WriteLine("Reversed");
            Console.WriteLine("Size,Bubble,Quick,Quick Random,Merge,Framework");
            for (int i = min; i <= max; i += increment)
            {
                list = GetReverseList(i);
                Console.Write(i + ",");
                Console.Write(SortTest(new List<int>(list), BubbleSort) + ",");
                Console.Write(SortTest(new List<int>(list), QuickSort) + ",");
                Console.Write(SortTest(new List<int>(list), QuickSortRandom) + ",");
                Console.Write(SortTest(new List<int>(list), MergeSort) + ",");
                Console.Write(SortTest(new List<int>(list), Sort) + "\r\n");
            }
        }

        private static double SortTest<T>(IList<T> list, Action<IList<T>> sort)
        {
            stopwatch.Restart();
            sort(list);
            stopwatch.Stop();
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

        private static List<int> GetRandomList(int count)
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
            for (int i = count; i > 0; i--)
                list.Add(i);
            return list;
        }
    }
}
