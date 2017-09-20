using System;
using System.IO;
using System.Text;
using Cookie.API.Utils.IO.Types;

namespace Cookie.API.Utils.IO
{
    public class BigEndianReader : IDataReader
    {
        private const int IntSize = 32;

        private const int ShortSize = 16;

        private const int ShortMaxValue = 32767;

        private const int UnsignedShortMaxValue = 65536;

        private const int ChunckBitSize = 7;

        private static int _maxEncodingLength = (int) Math.Ceiling((double) IntSize / ChunckBitSize);

        private const int Mask10000000 = 128;

        private const int Mask01111111 = 127;
        private BinaryReader _mReader;

        public BigEndianReader()
        {
            _mReader = new BinaryReader(new MemoryStream(), Encoding.UTF8);
        }

        public BigEndianReader(Stream stream)
        {
            _mReader = new BinaryReader(stream, Encoding.UTF8);
        }

        public BigEndianReader(byte[] tab)
        {
            _mReader = new BinaryReader(new MemoryStream(tab), Encoding.UTF8);
        }

        public Stream BaseStream => _mReader.BaseStream;

        public long BytesAvailable => (int) (_mReader.BaseStream.Length - _mReader.BaseStream.Position);

        public long Position => (int) _mReader.BaseStream.Position;

        public byte[] Data
        {
            get
            {
                var pos = BaseStream.Position;

                var data = new byte[BaseStream.Length];
                BaseStream.Position = 0;
                BaseStream.Read(data, 0, (int) BaseStream.Length);

                BaseStream.Position = pos;

                return data;
            }
        }

        public short ReadShort()
        {
            return BitConverter.ToInt16(ReadBigEndianBytes(2), 0);
        }

        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBigEndianBytes(4), 0);
        }

        public long ReadLong()
        {
            return BitConverter.ToInt64(ReadBigEndianBytes(8), 0);
        }

        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(ReadBigEndianBytes(2), 0);
        }

        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(ReadBigEndianBytes(4), 0);
        }

        public ulong ReadULong()
        {
            return BitConverter.ToUInt64(ReadBigEndianBytes(8), 0);
        }

        public byte ReadByte()
        {
            return _mReader.ReadByte();
        }

        public sbyte ReadSByte()
        {
            return _mReader.ReadSByte();
        }

        public byte[] ReadBytes(int n)
        {
            return _mReader.ReadBytes(n);
        }

        public bool ReadBoolean()
        {
            return _mReader.ReadByte() == 1;
        }

        public char ReadChar()
        {
            return (char) ReadUShort();
        }

        public double ReadDouble()
        {
            return BitConverter.ToDouble(ReadBigEndianBytes(8), 0);
        }

        public string ReadUTF()
        {
            var n = ReadUShort();
            var bytes = ReadBytes(n);
            return Encoding.UTF8.GetString(bytes);
        }

        public string ReadUTFBytes(ushort len)
        {
            var bytes = ReadBytes(len);
            return Encoding.UTF8.GetString(bytes);
        }

        public void SkipBytes(int n)
        {
            for (var i = 0; i < n; i++)
                _mReader.ReadByte();
        }

        public void Seek(int offset, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            _mReader.BaseStream.Seek(offset, seekOrigin);
        }

        public int ReadVarInt()
        {
            var value = 0;
            var offset = 0;
            while (offset < IntSize)
            {
                int b = ReadByte();
                var hasNext = (b & Mask10000000) == Mask10000000;
                if (offset > 0)
                    value = value + ((b & Mask01111111) << offset);
                else
                    value = value + (b & Mask01111111);
                offset = offset + ChunckBitSize;
                if (!hasNext)
                    return value;
            }
            throw new Exception("Too much data");
        }

        public uint ReadVarUhInt()
        {
            uint value = 0;
            var offset = 0;
            while (offset < IntSize)
            {
                int b = ReadByte();
                var hasNext = (b & Mask10000000) == Mask10000000;
                if (offset > 0)
                    value = (uint) (value + ((b & Mask01111111) << offset));
                else
                    value = (uint) (value + (b & Mask01111111));
                offset = offset + ChunckBitSize;
                if (!hasNext)
                    return value;
            }
            throw new Exception("Too much data");
        }

        public short ReadVarShort()
        {
            short value = 0;
            var offset = 0;
            while (offset < ShortSize)
            {
                int b = ReadByte();
                var hasNext = (b & Mask10000000) == Mask10000000;
                if (offset > 0)
                    value = (short) (value + ((b & Mask01111111) << offset));
                else
                    value = (short) (value + (b & Mask01111111));
                offset = offset + ChunckBitSize;
                if (hasNext) continue;
                if (value > ShortMaxValue)
                    value = (short) (value - UnsignedShortMaxValue);
                return value;
            }
            throw new Exception("Too much data");
        }

        public ushort ReadVarUhShort()
        {
            ushort value = 0;
            var offset = 0;
            while (offset < ShortSize)
            {
                int b = ReadByte();
                var hasNext = (b & Mask10000000) == Mask10000000;
                if (offset > 0)
                    value = (ushort) (value + ((b & Mask01111111) << offset));
                else
                    value = (ushort) (value + (b & Mask01111111));
                offset = offset + ChunckBitSize;
                if (hasNext) continue;
                if (value > ShortMaxValue)
                    value = (ushort) (value - UnsignedShortMaxValue);
                return value;
            }
            throw new Exception("Too much data");
        }

        public long ReadVarLong()
        {
            return ReadInt64().toNumber();
        }

        public ulong ReadVarUhLong()
        {
            return ReadUInt64().toNumber();
        }

        public void Dispose()
        {
            _mReader.Dispose();
            _mReader = null;
        }

        private byte[] ReadBigEndianBytes(int count)
        {
            var array = new byte[count];
            for (var i = count - 1; i >= 0; i--)
                array[i] = (byte) BaseStream.ReadByte();
            return array;
        }

        public BigEndianReader ReadBytesInNewBigEndianReader(int n)
        {
            return new BigEndianReader(_mReader.ReadBytes(n));
        }

        public float ReadSingle()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        public string ReadUtf7BitLength()
        {
            var n = ReadInt();
            var bytes = ReadBytes(n);
            return Encoding.UTF8.GetString(bytes);
        }

        public void Add(byte[] data, int offset, int count)
        {
            var position = _mReader.BaseStream.Position;
            _mReader.BaseStream.Position = _mReader.BaseStream.Length;
            _mReader.BaseStream.Write(data, offset, count);
            _mReader.BaseStream.Position = position;
        }

        private CustomInt64 ReadInt64()
        {
            uint b;
            var result = new CustomInt64();
            var i = 0;
            while (true)
            {
                b = ReadByte();
                if (i == 28)
                    break;
                if (b >= 128)
                {
                    result.low = result.low | ((b & 127) << i);
                    i = i + 7;
                    continue;
                }
                result.low = result.low | (b << i);
                return result;
            }

            if (b >= 128)
            {
                b = b & 127;
                result.low = result.low | (b << i);
                result.high = b >> 4;
                i = 3;
                while (true)
                {
                    b = ReadByte();
                    if (i < 32)
                        if (b >= 128)
                            result.high = result.high | ((b & 127) << i);
                        else
                            break;
                    i = i + 7;
                }

                result.high = result.high | (b << i);
                return result;
            }
            result.low = result.low | (b << i);
            result.high = b >> 4;
            return result;
        }

        private CustomUInt64 ReadUInt64()
        {
            uint b;
            var result = new CustomUInt64();
            var i = 0;
            while (true)
            {
                b = ReadByte();
                if (i == 28)
                    break;
                if (b >= 128)
                {
                    result.low = result.low | ((b & 127) << i);
                    i = i + 7;
                    continue;
                }
                result.low = result.low | (b << i);
                return result;
            }

            if (b >= 128)
            {
                b = b & 127;
                result.low = result.low | (b << i);
                result.high = b >> 4;
                i = 3;
                while (true)
                {
                    b = ReadByte();
                    if (i < 32)
                        if (b >= 128)
                            result.high = result.high | ((b & 127) << i);
                        else
                            break;
                    i = i + 7;
                }

                result.high = result.high | (b << i);
                return result;
            }
            result.low = result.low | (b << i);
            result.high = b >> 4;
            return result;
        }
    }
}