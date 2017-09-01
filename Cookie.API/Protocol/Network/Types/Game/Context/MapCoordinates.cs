using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    public class MapCoordinates : NetworkType
    {
        public const ushort ProtocolId = 174;

        public MapCoordinates(short worldX, short worldY)
        {
            WorldX = worldX;
            WorldY = worldY;
        }

        public MapCoordinates()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short WorldX { get; set; }
        public short WorldY { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(IDataReader reader)
        {
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}