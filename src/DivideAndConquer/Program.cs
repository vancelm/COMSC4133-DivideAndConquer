/*******************************************************************************
* Student: Vance Morgan
* Instructor: Dr. Evert
* Course: COMSC-4133.1410 Design/Analysis Comp Algorithms
* Semester: Summer 2021
* Assignment: Divide and Conquer
*******************************************************************************/

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

            List<int> list = new List<int>(unsortedList);
            ValidateSort(sortedList, list, () => list.BubbleSort(), "Bubble");

            list = new List<int>(unsortedList);
            ValidateSort(sortedList, list, () => list.QuickSort(), "Quick");

            list = new List<int>(unsortedList);
            ValidateSort(sortedList, list, () => list.MergeSort(), "Merge");
        }

        private static void ValidateSort<T>(List<T> sortedList, List<T> list, Action sort, string name)
        {
            sort();
            Console.Write(name + ": " + string.Join(",", list));

            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Equals(sortedList[i]))
                {
                    Console.WriteLine(" <FAIL>");
                    return;
                }
            }

            Console.WriteLine(" <PASS>");
        }

        private static void RunTests()
        {
            Console.WriteLine();
            Console.WriteLine("Random");
            Test(GetRandomList);

            Console.WriteLine();
            Console.WriteLine("Sequential");
            Test(GetSequentialList);

            Console.WriteLine();
            Console.WriteLine("Reversed");
            Test(GetReverseList);
        }

        private static void Test(Func<int, List<int>> getList)
        {
            for (int i = 1; i <= 1000000000; i *= 10)
            {
                List<int> list = getList(i);
                Console.Write(i + ",");
                //Console.Write(SortTest(() => new List<int>(list).BubbleSort()) + ",");
                Console.Write(SortTest(() => new List<int>(list).QuickSort()) + ",");
                Console.Write(SortTest(() => new List<int>(list).MergeSort()) + ",");
                Console.Write(SortTest(() => new List<int>(list).Sort()) + "\r\n");
            }
        }

        private static double SortTest(Action sort)
        {
            stopwatch.Restart();
            sort();
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
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
            for (int i = count - 1; i >= 0; i--)
                list.Add(i);
            return list;
        }
    }
}
