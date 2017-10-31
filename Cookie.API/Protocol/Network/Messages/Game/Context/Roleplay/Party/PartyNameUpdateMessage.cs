namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyNameUpdateMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6502;
        public override ushort MessageID => ProtocolId;
        public string PartyName { get; set; }

        public PartyNameUpdateMessage(string partyName)
        {
            PartyName = partyName;
        }

        public PartyNameUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyName = reader.ReadUTF();
        }

    }
}
