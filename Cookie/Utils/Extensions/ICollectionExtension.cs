using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.Utils.Extensions
{
    public static class ICollectionExtension
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> seq, Action<T> action)
        {
            foreach (var item in seq)
            {
                action(item);
                yield return item;
            }
        }
    }
}
