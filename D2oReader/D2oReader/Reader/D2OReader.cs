using System;
using System.Linq;
using System.Text;
using System.IO;

namespace D2oReader
{
    public class D2OReader : IDisposable
    {
        BinaryReader reader;

        public D2OReader(Stream input)
        {
            reader = new BinaryReader(input);
        }

        public int Pointer
        {
            get { return (int) reader.BaseStream.Position; }
            set { reader.BaseStream.Position = value; }
        }

        public int Length
        {
            get { return (int)reader.BaseStream.Length; }
        }

        public uint BytesAvailable
        {
            get { return (UInt32) (reader.BaseStream.Length - reader.BaseStream.Position); }
        }

        public bool ReadBool()
        {
            return reader.ReadBoolean();
        }
        public int ReadInt()
        {
            byte[] int32 = reader.ReadBytes(4);

            int32 = int32.Reverse().ToArray();

            return BitConverter.ToInt32(int32, 0);
        }

        public uint ReadUInt()
        {
            byte[] uint32 = reader.ReadBytes(4);

            uint32 = uint32.Reverse().ToArray();

            return BitConverter.ToUInt32(uint32, 0);
        }

        public short ReadShort()
        {
            byte[] @short = reader.ReadBytes(2);

            @short = @short.Reverse().ToArray();

            return BitConverter.ToInt16(@short, 0);
        }

        public ushort ReadUShort()
        {
            byte[] @ushort = reader.ReadBytes(2);

            @ushort = @ushort.Reverse().ToArray();

            return BitConverter.ToUInt16(@ushort, 0);
        }

        public byte[] ReadBytes(int bytesAmount)
        {
            return reader.ReadBytes(bytesAmount);
        }

        public sbyte ReadSByte()
        {
            return reader.ReadSByte();
        }

        public double ReadDouble()
        {
            byte[] @double = reader.ReadBytes(8);

            @double = @double.Reverse().ToArray();

            return BitConverter.ToDouble(@double, 0);
        }

        public float ReadFloat()
        {
            byte[] @float = reader.ReadBytes(4);

            @float = @float.Reverse().ToArray();

            return BitConverter.ToSingle(@float, 0);
        }

        public string ReadAscii(int bytesAmount)
        {
            byte[] buffer = reader.ReadBytes(bytesAmount);

            return Encoding.ASCII.GetString(buffer);
        }

        public string ReadUtf8()
        {
            byte[] buffer;

            ushort len = ReadUShort();

            buffer = reader.ReadBytes(len);

            return Encoding.UTF8.GetString(buffer);
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
