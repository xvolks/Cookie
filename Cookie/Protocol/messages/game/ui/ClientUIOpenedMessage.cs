using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ClientUIOpenedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6459;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Type = 0;

        public ClientUIOpenedMessage()
        {
        }

        public ClientUIOpenedMessage(
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