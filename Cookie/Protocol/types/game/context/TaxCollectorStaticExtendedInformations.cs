using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
    {
        public new const short ProtocolId = 440;
        public override short TypeId { get { return ProtocolId; } }

        public AllianceInformations AllianceIdentity;

        public TaxCollectorStaticExtendedInformations(): base()
        {
        }

        public TaxCollectorStaticExtendedInformations(
            short firstNameId,
            short lastNameId,
            GuildInformations guildIdentity,
            AllianceInformations allianceIdentity
        ): base(
            firstNameId,
            lastNameId,
            guildIdentity
        )
        {
            AllianceIdentity = allianceIdentity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            AllianceIdentity.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceIdentity = new AllianceInformations();
            AllianceIdentity.Deserialize(reader);
        }
    }
}