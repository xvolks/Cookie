namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    using Utils.IO;

    public class OrnamentSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6370;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public OrnamentSelectErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public OrnamentSelectErrorMessage() { }

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
