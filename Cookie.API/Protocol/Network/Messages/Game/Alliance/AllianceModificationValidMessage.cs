namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Guild;
    using Utils.IO;

    public class AllianceModificationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6450;
        public override ushort MessageID => ProtocolId;
        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem Alliancemblem { get; set; }

        public AllianceModificationValidMessage(string allianceName, string allianceTag, GuildEmblem alliancemblem)
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            Alliancemblem = alliancemblem;
        }

        public AllianceModificationValidMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }

    }
}
