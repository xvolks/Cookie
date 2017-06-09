using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cookie.IO.Types
{
    public class Int64 : Binary64
    {
        public int high { get; set; }
        public Int64(uint param1 = 0, uint param2 = 0)
            : base(param1, param2) { }

        public static Int64 fromNumber(double param1)
        {
            return new Int64((uint)param1, (uint)Math.Floor(param1 / 4.294967296E9));
        }

        public static implicit operator long(Int64 value)
        {
            return (long)value.toNumber();
        }

        public static Int64 parseInt64(string param1, uint param2 = 0)
        {
            uint _loc6_ = 0;
            bool _loc3_ = Regex.IsMatch(param1, "^\\-");
            uint _loc4_ = Convert.ToUInt32(_loc3_ ? 1 : 0);
            if (param2 == 0)
            {
                if (Regex.IsMatch(param1, "^\\-?0x"))
                {
                    param2 = 16;
                    _loc4_ = _loc4_ + 2;
                }
                else
                {
                    param2 = 10;
                }
            }
            if (param2 < 2 || param2 > 36)
            {
                throw new Exception("Invalid arguments");
            }
            else
            {
                param1 = param1.ToLower();
                Int64 _loc5_ = new Int64();
                while (_loc4_ < param1.Length)
                {
                    _loc6_ = Convert.ToUInt32(param1[(int)_loc4_]);
                    if (_loc6_ >= CHAR_CODE_0 && _loc6_ <= CHAR_CODE_9)
                    {
                        _loc6_ = _loc6_ - CHAR_CODE_0;
                    }
                    else if (_loc6_ >= CHAR_CODE_A && _loc6_ <= CHAR_CODE_Z)
                    {
                        _loc6_ = _loc6_ - CHAR_CODE_A;
                        _loc6_ = _loc6_ + 10;
                    }
                    else
                    {
                        throw new Exception();
                    }

                    if (_loc6_ >= param2)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        _loc5_.mul(param2);
                        _loc5_.add(_loc6_);
                        _loc4_++;
                        continue;
                    }
                }
                if (_loc3_)
                {
                    _loc5_.add(1);
                }
                return _loc5_;
            }
        }
        public double toNumber()
        {
            return this.high * 4.294967296E9 + low;
        }

        public string toString(uint param1)
        {
            uint _loc4_ = 0;
            switch (high)
            {
                case 0:
                    return low.ToString();
                case -1:
                    if (low == 0 && 2.147483648E9 == 0)
                    {
                        return Convert.ToString((low | (uint)2.147483648E9) - 2.147483648E9);
                    }
                    return low.ToString();
                default:
                    if (low == 0 && this.high == 0)
                    {
                        return "0";
                    }
                    List<char> _loc2_ = new List<char>();
                    UInt64 _loc3_ = new UInt64((uint)low, (uint)this.high);
                    if (this.high < 0)
                    {
                        _loc3_.add(1);
                    }
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
                    if (this.high < 0)
                    {
                        return "-" + _loc3_.low.ToString() + _loc2_;
                    }
                    return _loc3_.low.ToString() + _loc2_;
            }
        }
    }
}
