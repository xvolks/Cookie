using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.IO
{
    public class BooleanByteWrapper
    {
        public static byte SetFlag(byte flag, int number, bool value)
        {
            switch (number)
            {
                case 0:
                    flag = (byte)((value) ? (flag | 1) : (flag & (255 - 1)));
                    break;
                case 1:
                    flag = (byte)((value) ? (flag | 2) : (flag & (255 - 2)));
                    break;
                case 2:
                    flag = (byte)((value) ? (flag | 4) : (flag & (255 - 4)));
                    break;
                case 3:
                    flag = (byte)((value) ? (flag | 8) : (flag & (255 - 8)));
                    break;
                case 4:
                    flag = (byte)((value) ? (flag | 16) : (flag & (255 - 16)));
                    break;
                case 5:
                    flag = (byte)((value) ? (flag | 32) : (flag & (255 - 32)));
                    break;
                case 6:
                    flag = (byte)((value) ? (flag | 64) : (flag & (255 - 64)));
                    break;
                case 7:
                    flag = (byte)((value) ? (flag | 128) : (flag & (255 - 128)));
                    break;
            }
            return flag;
        }

        public static bool GetFlag(byte flag, int number)
        {
            switch (number)
            {
                case 0:
                    return (flag & 1) != 0;
                case 1:
                    return (flag & 2) != 0;
                case 2:
                    return (flag & 4) != 0;
                case 3:
                    return (flag & 8) != 0;
                case 4:
                    return (flag & 16) != 0;
                case 5:
                    return (flag & 32) != 0;
                case 6:
                    return (flag & 64) != 0;
                case 7:
                    return (flag & 128) != 0;
            }
            return false;
        }
    }
}
