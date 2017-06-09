namespace Cookie.IO
{
    public interface ICustomDataOutput : IDataWriter
    {
        void WriteVarInt(int value);

        void WriteVarUhInt(uint value);

        void WriteVarShort(short value);

        void WriteVarUhShort(ushort value);

        void WriteVarLong(long value);

        void WriteVarUhLong(ulong value);
    }
}
