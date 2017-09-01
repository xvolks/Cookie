namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class PaddockGuildedInformations : PaddockBuyableInformations
    {
        public new const ushort ProtocolId = 508;
        public override ushort TypeID => ProtocolId;
        public bool Deserted { get; set; }
        public GuildInformations GuildInfo { get; set; }

        public PaddockGuildedInformations(bool deserted, GuildInformations guildInfo)
        {
            Deserted = deserted;
            GuildInfo = guildInfo;
        }

        public PaddockGuildedInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Deserted);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Deserted = reader.ReadBoolean();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }

    }
}
