using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountsTakenFromPaddockMessage : NetworkMessage
    {
        public const uint ProtocolId = 6554;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public short WorldX = 0;
        public short WorldY = 0;
        public string Ownername;

        public ExchangeMountsTakenFromPaddockMessage()
        {
        }

        public ExchangeMountsTakenFromPaddockMessage(
            string name,
            short worldX,
            short worldY,
            string ownername
        )
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Ownername = ownername;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Ownername);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Ownername = reader.ReadUTF();
        }
    }
}