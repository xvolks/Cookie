using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyNameUpdateMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6502;
        public override uint MessageID { get { return ProtocolId; } }

        public string PartyName;

        public PartyNameUpdateMessage(): base()
        {
        }

        public PartyNameUpdateMessage(
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