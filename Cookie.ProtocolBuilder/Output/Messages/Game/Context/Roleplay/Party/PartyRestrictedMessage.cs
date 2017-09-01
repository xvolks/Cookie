namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyRestrictedMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6175;
        public override ushort MessageID => ProtocolId;
        public bool Restricted { get; set; }

        public PartyRestrictedMessage(bool restricted)
        {
            Restricted = restricted;
        }

        public PartyRestrictedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Restricted);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Restricted = reader.ReadBoolean();
        }

    }
}
