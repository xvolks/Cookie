using System;
using System.IO;
using System.Text;
using Cookie.API.Utils.IO.Types;

namespace Cookie.API.Utils.IO
{
    public class BigEndianReader : IDisposable, IDataReader
    {
        private BinaryReader m_reader;
        private static readonly int INT_SIZE = 32;

        private static readonly int SHORT_SIZE = 16;

        private static readonly int SHORT_MAX_VALUE = 32767;

        private static readonly int UNSIGNED_SHORT_MAX_VALUE = 65536;

        private static readonly int CHUNCK_BIT_SIZE = 7;

        private static int MAX_ENCODING_LENGTH = (int)Math.Ceiling((double)INT_SIZE / CHUNCK_BIT_SIZE);

        private static readonly int MASK_10000000 = 128;

        private static readonly int MASK_01111111 = 127;

        public BigEndianReader()
        {
            m_reader = new BinaryReader(new MemoryStream(), Encoding.UTF8);
        }

        public BigEndianReader(Stream stream)
        {
            m_reader = new BinaryReader(stream, Encoding.UTF8);
        }

        public BigEndianReader(byte[] tab)
        {
            m_reader = new BinaryReader(new MemoryStream(tab), Encoding.UTF8);
        }

        public Stream BaseStream => m_reader.BaseStream;

        public long BytesAvailable => (int) (m_reader.BaseStream.Length - m_reader.BaseStream.Position);

        public long Position => (int) m_reader.BaseStream.Position;

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
            return m_reader.ReadByte();
        }

        public sbyte ReadSByte()
        {
            return m_reader.ReadSByte();
        }

        public byte[] ReadBytes(int n)
        {
            return m_reader.ReadBytes(n);
        }

        public bool ReadBoolean()
        {
            return m_reader.ReadByte() == 1;
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
                m_reader.ReadByte();
        }

        public void Seek(int offset, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            m_reader.BaseStream.Seek(offset, seekOrigin);
        }

        public void Dispose()
        {
            m_reader.Dispose();
            m_reader = null;
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
            return new BigEndianReader(m_reader.ReadBytes(n));
        }

        public float ReadSingle()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        public string ReadUTF7BitLength()
        {
            var n = ReadInt();
            var bytes = ReadBytes(n);
            return Encoding.UTF8.GetString(bytes);
        }

        public void Add(byte[] data, int offset, int count)
        {
            var position = m_reader.BaseStream.Position;
            m_reader.BaseStream.Position = m_reader.BaseStream.Length;
            m_reader.BaseStream.Write(data, offset, count);
            m_reader.BaseStream.Position = position;
        }

        public int ReadVarInt()
        {
            var b = 0;
            var value = 0;
            var offset = 0;
            var hasNext = false;
            while (offset < INT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                    value = value + ((b & MASK_01111111) << offset);
                else
                    value = value + (b & MASK_01111111);
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                    return value;
            }
            throw new Exception("Too much data");
        }

        public uint ReadVarUhInt()
        {
            var b = 0;
            uint value = 0;
            var offset = 0;
            var hasNext = false;
            while (offset < INT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                    value = (uint)(value + ((b & MASK_01111111) << offset));
                else
                    value = (uint)(value + (b & MASK_01111111));
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                    return value;
            }
            throw new Exception("Too much data");
        }

        public short ReadVarShort()
        {
            var b = 0;
            short value = 0;
            var offset = 0;
            var hasNext = false;
            while (offset < SHORT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                    value = (short)(value + ((b & MASK_01111111) << offset));
                else
                    value = (short)(value + (b & MASK_01111111));
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                {
                    if (value > SHORT_MAX_VALUE)
                        value = (short)(value - UNSIGNED_SHORT_MAX_VALUE);
                    return value;
                }
            }
            throw new Exception("Too much data");
        }

        public ushort ReadVarUhShort()
        {
            var b = 0;
            ushort value = 0;
            var offset = 0;
            var hasNext = false;
            while (offset < SHORT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                    value = (ushort)(value + ((b & MASK_01111111) << offset));
                else
                    value = (ushort)(value + (b & MASK_01111111));
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                {
                    if (value > SHORT_MAX_VALUE)
                        value = (ushort)(value - UNSIGNED_SHORT_MAX_VALUE);
                    return value;
                }
            }
            throw new Exception("Too much data");
        }

        public long ReadVarLong()
        {
            return readInt64().toNumber();
        }

        public ulong ReadVarUhLong()
        {
            return readUInt64().toNumber();
        }

        private CustomInt64 readInt64()
        {
            uint b = 0;
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

        private CustomUInt64 readUInt64()
        {
            uint b = 0;
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