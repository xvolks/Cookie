namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 446;
        public override ushort TypeID => ProtocolId;
        public BasicGuildInformations Guild { get; set; }

        public TaxCollectorGuildInformations(BasicGuildInformations guild)
        {
            Guild = guild;
        }

        public TaxCollectorGuildInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }

    }
}
