using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Utils.Extensions
{
    public static class ArrayExtension
    {
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        public static T[] Shift<T>(this T[] source)
        {
            T[] aux = new T[source.Length - 1];
            Array.Copy(source, 1, aux, 0, source.Length);
            return aux;
        }
    }
}
