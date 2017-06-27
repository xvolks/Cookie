using System;
using System.IO;

namespace Cookie.API.Utils.IO
{
    public interface IDataReader : IDisposable
    {
        long Position { get; }

        long BytesAvailable { get; }

        byte[] Data { get; }

        short ReadShort();

        int ReadInt();

        long ReadLong();

        ushort ReadUShort();

        uint ReadUInt();

        ulong ReadULong();

        byte ReadByte();

        sbyte ReadSByte();

        byte[] ReadBytes(int n);

        bool ReadBoolean();

        char ReadChar();

        double ReadDouble();

        float ReadFloat();

        string ReadUTF();

        string ReadUTFBytes(ushort len);

        void Seek(int offset, SeekOrigin seekOrigin);

        void SkipBytes(int n);

        int ReadVarInt();

        uint ReadVarUhInt();

        short ReadVarShort();

        ushort ReadVarUhShort();

        long ReadVarLong();

        ulong ReadVarUhLong();
    }
}