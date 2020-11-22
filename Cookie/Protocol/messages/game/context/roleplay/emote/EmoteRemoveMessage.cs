using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EmoteRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 5687;
        public override uint MessageID { get { return ProtocolId; } }

        public byte EmoteId = 0;

        public EmoteRemoveMessage()
        {
        }

        public EmoteRemoveMessage(
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