using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceFactsErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6423;
        public override uint MessageID { get { return ProtocolId; } }

        public int AllianceId = 0;

        public AllianceFactsErrorMessage()
        {
        }

        public AllianceFactsErrorMessage(
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