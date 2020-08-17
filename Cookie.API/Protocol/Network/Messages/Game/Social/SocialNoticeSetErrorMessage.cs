using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    public class SocialNoticeSetErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6684;

        public SocialNoticeSetErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public SocialNoticeSetErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

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