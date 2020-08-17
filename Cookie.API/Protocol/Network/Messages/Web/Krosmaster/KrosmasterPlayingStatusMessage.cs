using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    public class KrosmasterPlayingStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6347;

        public KrosmasterPlayingStatusMessage(bool playing)
        {
            Playing = playing;
        }

        public KrosmasterPlayingStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Playing { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Playing);
        }

        public override void Deserialize(IDataReader reader)
        {
            Playing = reader.ReadBoolean();
        }
    }
}