using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LifePointsRegenBeginMessage : NetworkMessage
    {
        public const uint ProtocolId = 5684;
        public override uint MessageID { get { return ProtocolId; } }

        public byte RegenRate = 0;

        public LifePointsRegenBeginMessage()
        {
        }

        public LifePointsRegenBeginMessage(
            byte regenRate
        )
        {
            RegenRate = regenRate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RegenRate = reader.ReadByte();
        }
    }
}