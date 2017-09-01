using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    public class BulletinMessage : SocialNoticeMessage
    {
        public new const ushort ProtocolId = 6695;

        public BulletinMessage(int lastNotifiedTimestamp)
        {
            LastNotifiedTimestamp = lastNotifiedTimestamp;
        }

        public BulletinMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int LastNotifiedTimestamp { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LastNotifiedTimestamp);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LastNotifiedTimestamp = reader.ReadInt();
        }
    }
}