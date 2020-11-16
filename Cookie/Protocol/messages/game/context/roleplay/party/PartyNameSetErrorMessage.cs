using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyNameSetErrorMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6501;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Result = 0;

        public PartyNameSetErrorMessage(): base()
        {
        }

        public PartyNameSetErrorMessage(
            int partyId,
            byte result
        ): base(
            partyId
        )
        {
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Result);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Result = reader.ReadByte();
        }
    }
}