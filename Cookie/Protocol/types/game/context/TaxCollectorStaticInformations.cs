using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorStaticInformations : NetworkType
    {
        public const short ProtocolId = 147;
        public override short TypeId { get { return ProtocolId; } }

        public short FirstNameId = 0;
        public short LastNameId = 0;
        public GuildInformations GuildIdentity;

        public TaxCollectorStaticInformations()
        {
        }

        public TaxCollectorStaticInformations(
            short firstNameId,
            short lastNameId,
            GuildInformations guildIdentity
        )
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            GuildIdentity = guildIdentity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FirstNameId);
            writer.WriteVarShort(LastNameId);
            GuildIdentity.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FirstNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
            GuildIdentity = new GuildInformations();
            GuildIdentity.Deserialize(reader);
        }
    }
}