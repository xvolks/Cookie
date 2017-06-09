using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cookie.IO.Types
{
    public class UInt64 : Binary64
    {
        public UInt64(uint param1 = 0, uint param2 = 0) : base(param1, param2) { }

        public static UInt64 fromNumber(double param1)
        {
            return new UInt64((uint)param1, (uint)Math.Floor(param1 / 4.294967296E9));
        }


        public static implicit operator ulong(UInt64 value)
        {
            return (ulong)value.toNumber();
        }



        public static UInt64 parseUInt64(string param1, uint param2)
        {
            uint _loc5_ = 0;
            uint _loc3_ = 0;
            if (param2 == 0)
            {
                if (Regex.IsMatch(param1, "^0x"))
                {
                    param2 = 16;
                    _loc3_ = 2;
                }
                else
                {
                    param2 = 10;
                }
            }
            if (param2 < 2 || param2 > 36)
            {
                throw new Exception();
            }
            else
            {
                param1 = param1.ToLower();
                UInt64 _loc4_ = new UInt64();
                while (_loc3_ < param1.Length)
                {
                    _loc5_ = param1[(int)_loc3_];
                    if (_loc5_ >= CHAR_CODE_0 && _loc5_ <= CHAR_CODE_9)
                    {
                        _loc5_ = _loc5_ - CHAR_CODE_0;
                    }
                    else if (_loc5_ >= CHAR_CODE_A && _loc5_ <= CHAR_CODE_Z)
                    {
                        _loc5_ = _loc5_ - CHAR_CODE_A;
                        _loc5_ = _loc5_ + 10;
                    }
                    else
                    {
                        throw new Exception();
                    }

                    if (_loc5_ >= param2)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        _loc4_.mul(param2);
                        _loc4_.add(_loc5_);
                        _loc3_++;
                        continue;
                    }
                }
                return _loc4_;
            }
        }

        public int high { get; set; }

        public double toNumber()
        {
            return high * 4.294967296E9 + low;
        }

        public string toString(uint param1)
        {
            uint _loc4_ = 0;
            if (this.high == 0)
            {
                return low.ToString();
            }
            List<char> _loc2_ = new List<char>();
            UInt64 _loc3_ = new UInt64((uint)low, (uint)this.high);
            do
            {
                _loc4_ = _loc3_.div(param1);
                if (_loc4_ < 10)
                {
                    _loc2_.Add((char)(_loc4_ + CHAR_CODE_0));
                }
                else
                {
                    _loc2_.Add((char)(_loc4_ - 10 + CHAR_CODE_A));
                }
            }
            while (_loc3_.high != 0);
            _loc2_.Reverse();
            return _loc3_.low.ToString() + _loc2_;
        }
    }
}