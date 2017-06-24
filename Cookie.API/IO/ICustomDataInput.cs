namespace Cookie.API.IO
{
    public interface ICustomDataInput : IDataReader
    {
        int ReadVarInt();

        uint ReadVarUhInt();

        short ReadVarShort();

        ushort ReadVarUhShort();

        long ReadVarLong();

        ulong ReadVarUhLong();
    }
}