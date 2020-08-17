namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    using Utils.IO;

    public class GuildInAllianceVersatileInformations : GuildVersatileInformations
    {
        public new const ushort ProtocolId = 437;
        public override ushort TypeID => ProtocolId;
        public uint AllianceId { get; set; }

        public GuildInAllianceVersatileInformations(uint allianceId)
        {
            AllianceId = allianceId;
        }

        public GuildInAllianceVersatileInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUhInt();
        }

    }
}
