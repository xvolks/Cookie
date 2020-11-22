using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationFailedMessage : NetworkMessage
    {
        public const uint ProtocolId = 20;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 99;

        public IdentificationFailedMessage()
        {
        }

        public IdentificationFailedMessage(
            byte reason
        )
        {
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Reason = reader.ReadByte();
        }
    }
}