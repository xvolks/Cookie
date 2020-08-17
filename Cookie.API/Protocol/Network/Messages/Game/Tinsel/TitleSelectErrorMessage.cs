namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    using Utils.IO;

    public class TitleSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6373;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public TitleSelectErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public TitleSelectErrorMessage() { }

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
