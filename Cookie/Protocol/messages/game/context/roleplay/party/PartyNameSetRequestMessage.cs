using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyNameSetRequestMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6503;
        public override uint MessageID { get { return ProtocolId; } }

        public string PartyName;

        public PartyNameSetRequestMessage(): base()
        {
        }

        public PartyNameSetRequestMessage(
            int partyId,
            string partyName
        ): base(
            partyId
        )
        {
            PartyName = partyName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PartyName = reader.ReadUTF();
        }
    }
}