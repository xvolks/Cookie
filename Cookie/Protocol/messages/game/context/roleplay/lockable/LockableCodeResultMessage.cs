using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LockableCodeResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5672;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Result = 0;

        public LockableCodeResultMessage()
        {
        }

        public LockableCodeResultMessage(
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