using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountSterilizeFromPaddockMessage : NetworkMessage
    {
        public const uint ProtocolId = 6056;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public short WorldX = 0;
        public short WorldY = 0;
        public string Sterilizator;

        public ExchangeMountSterilizeFromPaddockMessage()
        {
        }

        public ExchangeMountSterilizeFromPaddockMessage(
            string name,
            short worldX,
            short worldY,
            string sterilizator
        )
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Sterilizator = sterilizator;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Sterilizator);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Sterilizator = reader.ReadUTF();
        }
    }
}