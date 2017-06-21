using System;
using System.Collections.Generic;

namespace Cookie.Utils.Extensions
{
    public static class ForEachExtensions
    {
        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            var idx = 0;
            foreach (var item in enumerable)
                handler(item, idx++);
        }
    }
}