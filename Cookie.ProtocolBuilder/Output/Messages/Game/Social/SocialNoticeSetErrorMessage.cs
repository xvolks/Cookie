namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    using Utils.IO;

    public class SocialNoticeSetErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6684;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public SocialNoticeSetErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public SocialNoticeSetErrorMessage() { }

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
