using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyLoyaltyStatusMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6270;

        public PartyLoyaltyStatusMessage(bool loyal)
        {
            Loyal = loyal;
        }

        public PartyLoyaltyStatusMessage()
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