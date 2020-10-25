using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyPledgeLoyaltyRequestMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6269;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Loyal = false;

        public PartyPledgeLoyaltyRequestMessage(): base()
        {
        }

        public PartyPledgeLoyaltyRequestMessage(
            int partyId,
            bool loyal
        ): base(
            partyId
        )
        {
            Loyal = loyal;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Loyal);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Loyal = reader.ReadBoolean();
        }
    }
}