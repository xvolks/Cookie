using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EmotePlayAbstractMessage : NetworkMessage
    {
        public const uint ProtocolId = 5690;
        public override uint MessageID { get { return ProtocolId; } }

        public byte EmoteId = 0;
        public double EmoteStartTime = 0;

        public EmotePlayAbstractMessage()
        {
        }

        public EmotePlayAbstractMessage(
            byte emoteId,
            double emoteStartTime
        )
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }
    }
}