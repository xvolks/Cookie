using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 5575;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyMemberInformations MemberInformations;

        public PartyUpdateMessage(): base()
        {
        }

        public PartyUpdateMessage(
            int partyId,
            PartyMemberInformations memberInformations
        ): base(
            partyId
        )
        {
            MemberInformations = memberInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MemberInformations.TypeId);
            MemberInformations.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var memberInformationsTypeId = reader.ReadShort();
            MemberInformations = new PartyMemberInformations();
            MemberInformations.Deserialize(reader);
        }
    }
}