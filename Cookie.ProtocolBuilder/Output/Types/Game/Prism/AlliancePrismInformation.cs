namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class AlliancePrismInformation : PrismInformation
    {
        public new const ushort ProtocolId = 427;
        public override ushort TypeID => ProtocolId;
        public AllianceInformations Alliance { get; set; }

        public AlliancePrismInformation(AllianceInformations alliance)
        {
            Alliance = alliance;
        }

        public AlliancePrismInformation() { }

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
