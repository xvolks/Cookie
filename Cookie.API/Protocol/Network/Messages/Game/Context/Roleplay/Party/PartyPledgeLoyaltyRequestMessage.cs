namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyPledgeLoyaltyRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6269;
        public override ushort MessageID => ProtocolId;
        public bool Loyal { get; set; }

        public PartyPledgeLoyaltyRequestMessage(bool loyal)
        {
            Loyal = loyal;
        }

        public PartyPledgeLoyaltyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Loyal);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Loyal = reader.ReadBoolean();
        }

    }
}
