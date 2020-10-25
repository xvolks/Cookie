using Cookie.IO.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.Utils.IO.Types
{
    public class Int64
    {
        public long Low { get; set; }

        public long High { get; set; }

        public Int64() { }

        public Int64(long low, long high)
        {
            Low = low;
            High = high;
        }

        public static Int64 FromNumber(long @long)
        {
            return new Int64(@long, (long)Math.Floor(@long / 4294967296.0));
        }

        public long ToNumber()
        {
            return High * 4294967296 + Low;
        }
    }

    public class UInt64 : Binary64
    {
        public UInt64(uint param1 = 0, uint param2 = 0)
            : base(param1, param2)
        {
            return;
        }// end function

        public ulong toNumber()
        {
            return (ulong)(internalHigh * 4294967296 + low);
        }

        public static Int64 fromNumber(double param1)
        {
            return new Int64(Convert.ToUInt32(param1), Convert.ToUInt32(Math.Floor(param1 / 4294967296)));
        }
    }
}
