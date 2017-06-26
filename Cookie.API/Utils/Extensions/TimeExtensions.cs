using System;

namespace Cookie.API.Utils.Extensions
{
    public static class TimeExtensions
    {
        public static long GetUnixTimeStampLong(this DateTime date)
        {
            return (long) date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime()).TotalMilliseconds;
        }

        public static int GetUnixTimeStamp(this DateTime date)
        {
            return (int) (date - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime()).TotalSeconds;
        }
    }
}