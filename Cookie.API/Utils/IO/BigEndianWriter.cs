using System;
using System.IO;
using System.Text;
using Cookie.API.Utils.IO.Types;

namespace Cookie.API.Utils.IO
{
    public class BigEndianWriter : IDisposable, IDataWriter
    {
        private static readonly int INT_SIZE = 32;

        private static readonly int SHORT_MIN_VALUE = -32768;

        private static readonly int SHORT_MAX_VALUE = 32767;

        private static readonly int UNSIGNED_SHORT_MAX_VALUE = 65536;

        private static readonly int CHUNCK_BIT_SIZE = 7;

        private static int MAX_ENCODING_LENGTH = (int) Math.Ceiling((double) INT_SIZE / CHUNCK_BIT_SIZE);

        private static readonly int MASK_10000000 = 128;

        private static readonly int MASK_01111111 = 127;
        private BinaryWriter m_writer;

        public BigEndianWriter()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        public BigEndianWriter(Stream stream)
        {
            m_writer = new BinaryWriter(stream, Encoding.UTF8);
        }

        public BigEndianWriter(byte[] buffer)
        {
            m_writer = new BinaryWriter(new MemoryStream(buffer));
        }

        public Stream BaseStream => m_writer.BaseStream;

        public long BytesAvailable => m_writer.BaseStream.Length - m_writer.BaseStream.Position;

        public int Position
        {
            get => (int) m_writer.BaseStream.Position;
            set => m_writer.BaseStream.Position = value;
        }

        public byte[] Data
        {
            get
            {
                var position = m_writer.BaseStream.Position;
                var array = new byte[m_writer.BaseStream.Length];
                m_writer.BaseStream.Position = 0L;
                m_writer.BaseStream.Read(array, 0, (int) m_writer.BaseStream.Length);
                m_writer.BaseStream.Position = position;
                return array;
            }
        }

        public void WriteShort(short @short)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@short));
        }

        public void WriteInt(int @int)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@int));
        }

        public void WriteLong(long @long)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@long));
        }

        public void WriteUShort(ushort @ushort)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ushort));
        }

        public void WriteUInt(uint @uint)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@uint));
        }

        public void WriteULong(ulong @ulong)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ulong));
        }

        public void WriteByte(byte @byte)
        {
            m_writer.Write(@byte);
        }

        public void WriteSByte(sbyte @byte)
        {
            m_writer.Write(@byte);
        }

        public void WriteFloat(float @float)
        {
            m_writer.Write(@float);
        }

        public void WriteBoolean(bool @bool)
        {
            if (@bool)
                m_writer.Write((byte) 1);
            else
                m_writer.Write((byte) 0);
        }

        public void WriteChar(char @char)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@char));
        }

        public void WriteDouble(double @double)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@double));
        }

        public void WriteSingle(float single)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(single));
        }

        public void WriteUTF(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var num = (ushort) bytes.Length;
            WriteUShort(num);
            for (var i = 0; i < (int) num; i++)
                m_writer.Write(bytes[i]);
        }

        public void WriteUTFBytes(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var num = bytes.Length;
            for (var i = 0; i < num; i++)
                m_writer.Write(bytes[i]);
        }

        public void WriteBytes(byte[] data)
        {
            m_writer.Write(data);
        }

        public void Seek(int offset)
        {
            Seek(offset, SeekOrigin.Begin);
        }

        public void Clear()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        public void WriteVarInt(int value)
        {
            if (value >= 0 && value <= MASK_01111111)
            {
                WriteByte((byte) value);
                return;
            }
            var b = 0;
            var c = value;
            while (c != 0 && c != -1)
            {
                b = c & MASK_01111111;
                c = c >> CHUNCK_BIT_SIZE;
                if (c > 0)
                    b = b | MASK_10000000;
                WriteByte((byte) b);
            }
        }

        public void WriteVarUhInt(uint value)
        {
            if (value <= MASK_01111111)
            {
                WriteByte((byte) value);
                return;
            }
            uint b = 0;
            var c = value;
            while (c != 0)
            {
                b = (uint) (c & MASK_01111111);
                c = c >> CHUNCK_BIT_SIZE;
                if (c > 0)
                    b = b | (uint) MASK_10000000;
                WriteByte((byte) b);
            }
        }

        public void WriteVarShort(short value)
        {
            if (value > SHORT_MAX_VALUE || value < SHORT_MIN_VALUE)
                throw new Exception("Forbidden value");
            var b = 0;
            if (value >= 0 && value <= MASK_01111111)
            {
                WriteByte((byte) value);
                return;
            }
            var c = value & 65535;
            while (c != 0 && c != -1)
            {
                b = c & MASK_01111111;
                c = c >> CHUNCK_BIT_SIZE;
                if (c > 0)
                    b = b | MASK_10000000;
                WriteByte((byte) b);
            }
        }

        public void WriteVarUhShort(ushort value)
        {
            if (value > UNSIGNED_SHORT_MAX_VALUE || value < SHORT_MIN_VALUE)
                throw new Exception("Forbidden value");
            var b = 0;
            if (value >= 0 && value <= MASK_01111111)
            {
                WriteByte((byte) value);
                return;
            }
            var c = value & 65535;
            while (c != 0)
            {
                b = c & MASK_01111111;
                c = c >> CHUNCK_BIT_SIZE;
                if (c > 0)
                    b = b | MASK_10000000;
                WriteByte((byte) b);
            }
        }

        public void WriteVarLong(long value)
        {
            uint i = 0;
            var val = CustomInt64.fromNumber(value);
            if (val.high == 0)
            {
                WriteInt32(val.low);
            }
            else
            {
                i = 0;
                while (i < 4)
                {
                    WriteByte((byte) ((val.low & 127) | 128));
                    val.low = val.low >> 7;
                    i++;
                }
                if ((val.high & (268435455 << 3)) == 0)
                {
                    WriteByte((byte) ((val.high << 4) | val.low));
                }
                else
                {
                    WriteByte((byte) ((((val.high << 4) | val.low) & 127) | 128));
                    WriteInt32(val.high >> 3);
                }
            }
        }

        public void WriteVarUhLong(ulong value)
        {
            WriteVarLong((long) value);
        }

        public void Dispose()
        {
            m_writer.Flush();
            m_writer.Dispose();
            m_writer = null;
        }

        private void WriteBigEndianBytes(byte[] endianBytes)
        {
            for (var i = endianBytes.Length - 1; i >= 0; i--)
                m_writer.Write(endianBytes[i]);
        }

        /// <summary>
        ///     Write a bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBytes(byte[] data, uint offset, uint length)
        {
            var array = new byte[length];
            Array.Copy(data, offset, array, 0, length);
            m_writer.Write(array);
        }

        public void Seek(int offset, SeekOrigin seekOrigin)
        {
            m_writer.BaseStream.Seek(offset, seekOrigin);
        }

        private void WriteInt32(uint value)
        {
            while (value >= 128)
            {
                WriteByte((byte) ((value & 127) | 128));
                value = value >> 7;
            }
            WriteByte((byte) value);
        }
    }
}