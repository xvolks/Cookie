namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5578;
        public override ushort MessageID => ProtocolId;
        public ulong PartyLeaderId { get; set; }

        public PartyLeaderUpdateMessage(ulong partyLeaderId)
        {
            PartyLeaderId = partyLeaderId;
        }

        public PartyLeaderUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PartyLeaderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyLeaderId = reader.ReadVarUhLong();
        }

    }
}
