using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyMemberRemoveMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 5579;
        public override uint MessageID { get { return ProtocolId; } }

        public long LeavingPlayerId = 0;

        public PartyMemberRemoveMessage(): base()
        {
        }

        public PartyMemberRemoveMessage(
            int partyId,
            long leavingPlayerId
        ): base(
            partyId
        )
        {
            LeavingPlayerId = leavingPlayerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(LeavingPlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LeavingPlayerId = reader.ReadVarLong();
        }
    }
}