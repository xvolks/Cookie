namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class IgnoredAddFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5679;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public IgnoredAddFailureMessage(byte reason)
        {
            Reason = reason;
        }

        public IgnoredAddFailureMessage() { }

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
