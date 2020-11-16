using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
    {
        public new const uint ProtocolId = 5588;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Enabled = false;

        public PartyFollowThisMemberRequestMessage(): base()
        {
        }

        public PartyFollowThisMemberRequestMessage(
            int partyId,
            long playerId,
            bool enabled
        ): base(
            partyId,
            playerId
        )
        {
            Enabled = enabled;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Enabled = reader.ReadBoolean();
        }
    }
}