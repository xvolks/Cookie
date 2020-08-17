namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    using Types.Game.Fight;
    using Utils.IO;

    public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 447;
        public override ushort TypeID => ProtocolId;
        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }

        public TaxCollectorWaitingForHelpInformations(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
        {
            WaitingForHelpInfo = waitingForHelpInfo;
        }

        public TaxCollectorWaitingForHelpInformations() { }

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
