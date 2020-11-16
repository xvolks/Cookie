using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SequenceNumberMessage : NetworkMessage
    {
        public const uint ProtocolId = 6317;
        public override uint MessageID { get { return ProtocolId; } }

        public short Number = 0;

        public SequenceNumberMessage()
        {
        }

        public SequenceNumberMessage(
            short number
        )
        {
            Number = number;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Number);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Number = reader.ReadShort();
        }
    }
}