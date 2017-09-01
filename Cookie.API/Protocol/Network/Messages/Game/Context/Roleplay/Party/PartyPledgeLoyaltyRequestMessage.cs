using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyPledgeLoyaltyRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6269;

        public PartyPledgeLoyaltyRequestMessage(bool loyal)
        {
            Loyal = loyal;
        }

        public PartyPledgeLoyaltyRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Loyal { get; set; }

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