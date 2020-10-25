using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HaapiAuthErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6768;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Type = 0;

        public HaapiAuthErrorMessage()
        {
        }

        public HaapiAuthErrorMessage(
            byte type
        )
        {
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
        }
    }
}