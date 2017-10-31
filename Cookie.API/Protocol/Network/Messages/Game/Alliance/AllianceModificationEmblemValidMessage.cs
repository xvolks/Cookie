namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Guild;
    using Utils.IO;

    public class AllianceModificationEmblemValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6447;
        public override ushort MessageID => ProtocolId;
        public GuildEmblem Alliancemblem { get; set; }

        public AllianceModificationEmblemValidMessage(GuildEmblem alliancemblem)
        {
            Alliancemblem = alliancemblem;
        }

        public AllianceModificationEmblemValidMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }

    }
}
