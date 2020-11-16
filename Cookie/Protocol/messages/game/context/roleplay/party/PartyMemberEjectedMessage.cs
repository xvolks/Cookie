using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyMemberEjectedMessage : PartyMemberRemoveMessage
    {
        public new const uint ProtocolId = 6252;
        public override uint MessageID { get { return ProtocolId; } }

        public long KickerId = 0;

        public PartyMemberEjectedMessage(): base()
        {
        }

        public PartyMemberEjectedMessage(
            int partyId,
            long leavingPlayerId,
            long kickerId
        ): base(
            partyId,
            leavingPlayerId
        )
        {
            KickerId = kickerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(KickerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            KickerId = reader.ReadVarLong();
        }
    }
}