using System;

namespace Cookie.API.Utils
{
    public static class FlashKeyGenerator
    {
        public static string GetRandomFlashKey(string accountName)
        {
            var str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var seed = 0x2A;
            var num3 = 0;
            var length = accountName.Length;
            while (num3 < length)
            {
                var ch = accountName[num3];
                seed = seed + (Convert.ToInt32(ch) - 3);
                num3 += 1;
            }
            var random = new Random(seed);
            var str3 = "";
            var num2 = 1;
            do
            {
                str3 = str3 + Convert.ToString(str[random.Next(0, str.Length)]);
                num2 += 1;
            } while (num2 <= 0x15);
            return str3;
        }
    }
}