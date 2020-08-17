namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
    {
        public new const ushort ProtocolId = 6445;
        public override ushort MessageID => ProtocolId;
        public BasicNamedAllianceInformations Alliance { get; set; }

        public AllianceTaxCollectorDialogQuestionExtendedMessage(BasicNamedAllianceInformations alliance)
        {
            Alliance = alliance;
        }

        public AllianceTaxCollectorDialogQuestionExtendedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicNamedAllianceInformations();
            Alliance.Deserialize(reader);
        }

    }
}
