using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountFreeFromPaddockMessage : NetworkMessage
    {
        public const uint ProtocolId = 6055;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public short WorldX = 0;
        public short WorldY = 0;
        public string Liberator;

        public ExchangeMountFreeFromPaddockMessage()
        {
        }

        public ExchangeMountFreeFromPaddockMessage(
            string name,
            short worldX,
            short worldY,
            string liberator
        )
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Liberator = liberator;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Liberator);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Liberator = reader.ReadUTF();
        }
    }
}