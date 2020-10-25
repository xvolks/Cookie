using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractPartyMessage : NetworkMessage
    {
        public const uint ProtocolId = 6274;
        public override uint MessageID { get { return ProtocolId; } }

        public int PartyId = 0;

        public AbstractPartyMessage()
        {
        }

        public AbstractPartyMessage(
            int partyId
        )
        {
            PartyId = partyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(PartyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PartyId = reader.ReadVarInt();
        }
    }
}