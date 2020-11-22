using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuestLimitationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6506;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 0;

        public GuestLimitationMessage()
        {
        }

        public GuestLimitationMessage(
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