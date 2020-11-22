using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Cookie.API.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ConcatCopy(this string str, int times)
        {
            var builder = new StringBuilder(str.Length * times);
            for (var i = 0; i < times; i++)
                builder.Append(str);
            return builder.ToString();
        }

        public static string DeleteLastLetter(this string str)
        {
            if (str.Length < 2)
                return str;
            return str.Substring(0, str.Length - 1);
        }

        public static int CountOccurences(this string str, char chr)
        {
            return str.CountOccurences(chr, 0, str.Length);
        }

        public static string GetMD5(this string encryptString)
        {
            var bytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(encryptString));
            return bytes.ByteArrayToString();
        }

        public static int CountOccurences(this string str, char chr, int startIndex, int count)
        {
            var occurences = 0;
            for (var i = startIndex; i < startIndex + count; i++)
                if (str[i] == chr)
                    occurences++;
            return occurences;
        }

        public static string EscapeString(this string str)
        {
            string str1;
            if (str == null)
                str1 = null;
            else
                str1 = Regex.Replace(str, "[\\r\\n\\x00\\x1a\\\\'\"]", "\\$0");
            return str1;
        }

        public static string FirstLetterUpper(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            var chArray = source.ToCharArray();
            chArray[0] = char.ToUpper(chArray[0]);
            return new string(chArray);
        }

        public static string HtmlEntities(this string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            return str;
        }

        public static string RandomString(this Random random, int size)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < size; i++)
                stringBuilder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))));
            return stringBuilder.ToString();
        }

        public static string[] SplitAdvanced(this string expression, string delimiter)
        {
            return expression.SplitAdvanced(delimiter, string.Empty, false);
        }

        public static string[] SplitAdvanced(this string expression, string delimiter, string qualifier)
        {
            return expression.SplitAdvanced(delimiter, qualifier, false);
        }

        public static string[] SplitAdvanced(this string expression, string delimiter, string qualifier,
            bool ignoreCase)
        {
            var qualifierState = false;
            var startIndex = 0;
            var values = new ArrayList();
            for (var charIndex = 0; charIndex < expression.Length - 1; charIndex++)
                if (qualifier != null)
                    if (string.Compare(expression.Substring(charIndex, qualifier.Length), qualifier, ignoreCase) == 0)
                    {
                        qualifierState = !qualifierState;
                    }
                    else if (!qualifierState & (delimiter != null) &
                             (string.Compare(expression.Substring(charIndex, delimiter.Length), delimiter,
                                  ignoreCase) == 0))
                    {
                        values.Add(expression.Substring(startIndex, charIndex - startIndex));
                        startIndex = charIndex + 1;
                    }
            if (startIndex < expression.Length)
                values.Add(expression.Substring(startIndex, expression.Length - startIndex));
            var returnValues = new string[values.Count];
            values.CopyTo(returnValues);
            return returnValues;
        }
    }
}