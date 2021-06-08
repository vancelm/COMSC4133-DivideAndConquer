using System;
using System.Collections.Generic;
using System.Linq;

namespace DivideAndConquer
{
    public static class ListExtensions
    {
        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            T t = list[a];
            list[a] = list[b];
            list[b] = t;
        }
    }
}