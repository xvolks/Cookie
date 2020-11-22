﻿using System;

namespace Cookie.API.Utils.IO.Types
{
    public class CustomInt64 : Binary64
    {
        public CustomInt64()
        {
        }

        public CustomInt64(uint low = 0, uint high = 0)
            : base(low, high)
        {
        }

        public uint high
        {
            get => internalHigh;
            set => internalHigh = value;
        }

        public static CustomInt64 fromNumber(long n)
        {
            return new CustomInt64((uint) n, (uint) Math.Floor(n / 4.294967296E9));
        }

        public long toNumber()
        {
            return (long) (high * 4.294967296E9 + low);
        }
    }
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
}