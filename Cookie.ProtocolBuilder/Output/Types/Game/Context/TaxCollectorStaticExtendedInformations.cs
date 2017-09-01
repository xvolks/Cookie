namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
    {
        public new const ushort ProtocolId = 440;
        public override ushort TypeID => ProtocolId;
        public AllianceInformations AllianceIdentity { get; set; }

        public TaxCollectorStaticExtendedInformations(AllianceInformations allianceIdentity)
        {
            AllianceIdentity = allianceIdentity;
        }

        public TaxCollectorStaticExtendedInformations() { }

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
