namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyAbdicateThroneMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6080;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public PartyAbdicateThroneMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public PartyAbdicateThroneMessage() { }

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
