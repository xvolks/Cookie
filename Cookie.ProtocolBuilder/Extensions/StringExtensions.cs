namespace Cookie.ProtocolBuilder.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1, s.Length - 1);
        }

        public static string Decapitalize(this string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1, s.Length - 1);
        }

        public static string ToValidName(this string s)
        {
            switch (s)
            {
                case "object":
                    return $"@{s}";
                case "base":
                    return $"@{s}";
                case "params":
                    return $"@{s}";
            }
            return s;
        }

        public static string ToConverterCSharp(this string s)
        {
            return s.Contains("Short") ? $"({s.Replace("Write", "").ToLower()})" : "";
        }
    }
}