namespace Cookie.API.Protocol.Network.Messages.Connection.Search
{
    using Utils.IO;

    public class AcquaintanceSearchErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6143;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public AcquaintanceSearchErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public AcquaintanceSearchErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
