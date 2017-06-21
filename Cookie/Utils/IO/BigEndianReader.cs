using System;
using System.IO;
using System.Text;

namespace Cookie.IO
{
    public class BigEndianReader : IDisposable, IDataReader
    {
        private BinaryReader m_reader;

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
    }
}