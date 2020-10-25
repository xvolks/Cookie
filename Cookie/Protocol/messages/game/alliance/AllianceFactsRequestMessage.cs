using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceFactsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6409;
        public override uint MessageID { get { return ProtocolId; } }

        public int AllianceId = 0;

        public AllianceFactsRequestMessage()
        {
        }

        public AllianceFactsRequestMessage(
            int allianceId
        )
        {
            AllianceId = allianceId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(AllianceId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceId = reader.ReadVarInt();
        }
    }
}