namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class TaxCollectorStaticInformations : NetworkType
    {
        public const ushort ProtocolId = 147;
        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public GuildInformations GuildIdentity { get; set; }

        public TaxCollectorStaticInformations(ushort firstNameId, ushort lastNameId, GuildInformations guildIdentity)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            GuildIdentity = guildIdentity;
        }

        public TaxCollectorStaticInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            GuildIdentity.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            GuildIdentity = new GuildInformations();
            GuildIdentity.Deserialize(reader);
        }

    }
}
