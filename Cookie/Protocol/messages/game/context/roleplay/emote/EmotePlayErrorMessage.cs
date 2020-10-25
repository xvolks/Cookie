using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EmotePlayErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5688;
        public override uint MessageID { get { return ProtocolId; } }

        public byte EmoteId = 0;

        public EmotePlayErrorMessage()
        {
        }

        public EmotePlayErrorMessage(
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