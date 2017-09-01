namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    using Utils.IO;

    public class KrosmasterInventoryErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6343;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public KrosmasterInventoryErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public KrosmasterInventoryErrorMessage() { }

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
