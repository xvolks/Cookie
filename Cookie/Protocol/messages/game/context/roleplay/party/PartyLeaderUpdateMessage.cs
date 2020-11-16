using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 5578;
        public override uint MessageID { get { return ProtocolId; } }

        public long PartyLeaderId = 0;

        public PartyLeaderUpdateMessage(): base()
        {
        }

        public PartyLeaderUpdateMessage(
            int partyId,
            long partyLeaderId
        ): base(
            partyId
        )
        {
            PartyLeaderId = partyLeaderId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PartyLeaderId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PartyLeaderId = reader.ReadVarLong();
        }
    }
}