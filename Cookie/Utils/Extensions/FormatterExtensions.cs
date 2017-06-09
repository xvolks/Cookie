using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cookie.Extensions
{
    public static class FormatterExtensions
    {
        public static string ToCSV(this IEnumerable enumerable, string separator)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = 0;
            foreach (object current in enumerable)
            {
                stringBuilder.Append(current);
                stringBuilder.Append(separator);
                num++;
            }
            if (num > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
            }
            return stringBuilder.ToString();
        }

        public static string ToCSV<T>(this IEnumerable<T> enumerable, string separator, Func<T, string> formatter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = 0;
            foreach (T current in enumerable)
            {
                stringBuilder.Append(formatter(current));
                stringBuilder.Append(separator);
                num++;
            }
            if (num > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
            }
            return stringBuilder.ToString();
        }

        public static T[] FromCSV<T>(this string csvValue, string separator) where T : IConvertible
        {
            List<T> list = new List<T>();
            int num = 0;
            int num2 = csvValue.IndexOf(separator, StringComparison.Ordinal);
            while (num2 >= 0 && num2 < csvValue.Length)
            {
                list.Add((T)((object)Convert.ChangeType(csvValue.Substring(num, num2 - num), typeof(T))));
                num = num2 + separator.Length;
                num2 = csvValue.IndexOf(separator, num, StringComparison.Ordinal);
            }
            if (!string.IsNullOrEmpty(csvValue))
            {
                list.Add((T)((object)Convert.ChangeType(csvValue.Substring(num, csvValue.Length - num), typeof(T))));
            }
            return list.ToArray();
        }

        public static T[] FromCSV<T>(this string csvValue, string separator, Func<string, T> converter)
        {
            List<T> list = new List<T>();
            int num = 0;
            int num2 = csvValue.IndexOf(separator, StringComparison.Ordinal);
            while (num2 >= 0 && num2 < csvValue.Length)
            {
                list.Add(converter(csvValue.Substring(num, num2 - num)));
                num = num2 + separator.Length;
                num2 = csvValue.IndexOf(separator, num, StringComparison.Ordinal);
            }
            if (!string.IsNullOrEmpty(csvValue))
            {
                list.Add(converter(csvValue.Substring(num, csvValue.Length - num)));
            }
            return list.ToArray();
        }
    }
}
