using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountDataErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6172;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 0;

        public MountDataErrorMessage()
        {
        }

        public MountDataErrorMessage(
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