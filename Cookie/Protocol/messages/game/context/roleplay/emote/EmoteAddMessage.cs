using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EmoteAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5644;
        public override uint MessageID { get { return ProtocolId; } }

        public byte EmoteId = 0;

        public EmoteAddMessage()
        {
        }

        public EmoteAddMessage(
            byte emoteId
        )
        {
            EmoteId = emoteId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            EmoteId = reader.ReadByte();
        }
    }
}