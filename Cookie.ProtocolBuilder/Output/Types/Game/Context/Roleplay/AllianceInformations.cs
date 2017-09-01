namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Guild;
    using Utils.IO;

    public class AllianceInformations : BasicNamedAllianceInformations
    {
        public new const ushort ProtocolId = 417;
        public override ushort TypeID => ProtocolId;
        public GuildEmblem AllianceEmblem { get; set; }

        public AllianceInformations(GuildEmblem allianceEmblem)
        {
            AllianceEmblem = allianceEmblem;
        }

        public AllianceInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }

    }
}
