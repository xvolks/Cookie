using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceCreationResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6391;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Result = 0;

        public AllianceCreationResultMessage()
        {
        }

        public AllianceCreationResultMessage(
            byte result
        )
        {
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Result = reader.ReadByte();
        }
    }
}