using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyCannotJoinErrorMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5583;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 0;

        public PartyCannotJoinErrorMessage(): base()
        {
        }

        public PartyCannotJoinErrorMessage(
            int partyId,
            byte reason
        ): base(
            partyId
        )
        {
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadByte();
        }
    }
}