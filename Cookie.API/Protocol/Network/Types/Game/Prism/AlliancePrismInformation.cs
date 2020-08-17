using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    public class AlliancePrismInformation : PrismInformation
    {
        public new const ushort ProtocolId = 427;

        public AlliancePrismInformation(AllianceInformations alliance)
        {
            Alliance = alliance;
        }

        public AlliancePrismInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public AllianceInformations Alliance { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new AllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}