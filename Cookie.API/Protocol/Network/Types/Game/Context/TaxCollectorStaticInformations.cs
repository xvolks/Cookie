using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    public class TaxCollectorStaticInformations : NetworkType
    {
        public const ushort ProtocolId = 147;

        public TaxCollectorStaticInformations(ushort firstNameId, ushort lastNameId, GuildInformations guildIdentity)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            GuildIdentity = guildIdentity;
        }

        public TaxCollectorStaticInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public GuildInformations GuildIdentity { get; set; }

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