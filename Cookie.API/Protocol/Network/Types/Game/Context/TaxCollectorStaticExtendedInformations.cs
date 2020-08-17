using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
    {
        public new const ushort ProtocolId = 440;

        public TaxCollectorStaticExtendedInformations(AllianceInformations allianceIdentity)
        {
            AllianceIdentity = allianceIdentity;
        }

        public TaxCollectorStaticExtendedInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public AllianceInformations AllianceIdentity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceIdentity.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceIdentity = new AllianceInformations();
            AllianceIdentity.Deserialize(reader);
        }
    }
}