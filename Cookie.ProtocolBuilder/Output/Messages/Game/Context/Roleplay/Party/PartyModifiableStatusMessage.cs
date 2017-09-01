namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyModifiableStatusMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6277;
        public override ushort MessageID => ProtocolId;
        public bool Enabled { get; set; }

        public PartyModifiableStatusMessage(bool enabled)
        {
            Enabled = enabled;
        }

        public PartyModifiableStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Enabled = reader.ReadBoolean();
        }

    }
}
