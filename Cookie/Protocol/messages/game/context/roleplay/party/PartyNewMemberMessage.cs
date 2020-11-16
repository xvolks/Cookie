using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyNewMemberMessage : PartyUpdateMessage
    {
        public new const uint ProtocolId = 6306;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyNewMemberMessage(): base()
        {
        }

        public PartyNewMemberMessage(
            int partyId,
            PartyMemberInformations memberInformations
        ): base(
            partyId,
            memberInformations
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}