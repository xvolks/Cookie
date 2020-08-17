namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyMemberRemoveMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5579;
        public override ushort MessageID => ProtocolId;
        public ulong LeavingPlayerId { get; set; }

        public PartyMemberRemoveMessage(ulong leavingPlayerId)
        {
            LeavingPlayerId = leavingPlayerId;
        }

        public PartyMemberRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(LeavingPlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeavingPlayerId = reader.ReadVarUhLong();
        }

    }
}
