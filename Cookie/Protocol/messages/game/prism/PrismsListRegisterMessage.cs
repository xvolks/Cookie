using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismsListRegisterMessage : NetworkMessage
    {
        public const uint ProtocolId = 6441;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Listen = 0;

        public PrismsListRegisterMessage()
        {
        }

        public PrismsListRegisterMessage(
            byte listen
        )
        {
            Listen = listen;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Listen);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Listen = reader.ReadByte();
        }
    }
}