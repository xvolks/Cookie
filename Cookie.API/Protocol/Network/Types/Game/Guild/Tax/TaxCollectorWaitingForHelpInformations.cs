using Cookie.API.Protocol.Network.Types.Game.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 447;

        public TaxCollectorWaitingForHelpInformations(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
        {
            WaitingForHelpInfo = waitingForHelpInfo;
        }

        public TaxCollectorWaitingForHelpInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            WaitingForHelpInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            WaitingForHelpInfo.Deserialize(reader);
        }
    }
}