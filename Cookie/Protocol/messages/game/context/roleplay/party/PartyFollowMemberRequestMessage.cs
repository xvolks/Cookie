using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyFollowMemberRequestMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5577;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public PartyFollowMemberRequestMessage(): base()
        {
        }

        public PartyFollowMemberRequestMessage(
            int partyId,
            long playerId
        ): base(
            partyId
        )
        {
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
        }
    }
}