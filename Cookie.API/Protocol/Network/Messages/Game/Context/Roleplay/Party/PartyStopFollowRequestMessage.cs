namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyStopFollowRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5574;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public PartyStopFollowRequestMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public PartyStopFollowRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
