using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MapCoordinates : NetworkType
    {
        public const short ProtocolId = 174;
        public override short TypeId { get { return ProtocolId; } }

        public short WorldX = 0;
        public short WorldY = 0;

        public MapCoordinates()
        {
        }

        public MapCoordinates(
            short worldX,
            short worldY
        )
        {
            WorldX = worldX;
            WorldY = worldY;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}