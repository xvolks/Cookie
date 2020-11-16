using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceModificationNameAndTagValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6449;
        public override uint MessageID { get { return ProtocolId; } }

        public string AllianceName;
        public string AllianceTag;

        public AllianceModificationNameAndTagValidMessage()
        {
        }

        public AllianceModificationNameAndTagValidMessage(
            string allianceName,
            string allianceTag
        )
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
        }
    }
}