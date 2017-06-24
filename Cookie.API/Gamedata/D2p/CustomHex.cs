using System;
using System.Text;

namespace Cookie.API.Gamedata.D2p
{
    public class CustomHex
    {
        // Methods
        public static string FromArray(byte[] ByteArray, bool Flag = false)
        {
            var str = "";
            var num = ByteArray.Length - 1;
            var i = 0;
            while (i <= num)
            {
                var str2 = ByteArray[i].ToString("x");
                if (str2.Length == 1)
                    str2 = "0" + str2;
                str = str + str2;
                if (Flag && i < ByteArray.Length - 1)
                    str = str + ":";
                i += 1;
            }
            return str;
        }

        public static string FromString(string Str, bool Flag = false)
        {
            return FromArray(Encoding.ASCII.GetBytes(Str), false);
        }

        public static byte[] ToArray(string Str)
        {
            Str = Str.Replace(" ", "").Replace(":", "").Trim();
            if ((Str.Length & 1) == 1)
                Str = "0" + Str;
            var buffer = new byte[Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToDouble(Str.Length) / 2 - 1))) +
                                  1];
            var num = Str.Length - 1;
            var i = 0;
            while (i <= num)
            {
                buffer[Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToDouble(i) / 2)))] =
                    Convert.ToByte(Convert.ToInt32(Str.Substring(i, 2), 0x10));
                i = i + 2;
            }
            return buffer;
        }

        public string ToString(string str)
        {
            return Encoding.ASCII.GetString(ToArray(str));
        }
    }
}