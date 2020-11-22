using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyKickedByMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5590;
        public override uint MessageID { get { return ProtocolId; } }

        public long KickerId = 0;

        public PartyKickedByMessage(): base()
        {
        }

        public PartyKickedByMessage(
            int partyId,
            long kickerId
        ): base(
            partyId
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