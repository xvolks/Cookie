namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismInfoInValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5859;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public PrismInfoInValidMessage(byte reason)
        {
            Reason = reason;
        }

        public PrismInfoInValidMessage() { }

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
