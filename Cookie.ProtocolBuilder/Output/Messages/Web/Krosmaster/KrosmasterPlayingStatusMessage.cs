namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    using Utils.IO;

    public class KrosmasterPlayingStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6347;
        public override ushort MessageID => ProtocolId;
        public bool Playing { get; set; }

        public KrosmasterPlayingStatusMessage(bool playing)
        {
            Playing = playing;
        }

        public KrosmasterPlayingStatusMessage() { }

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
