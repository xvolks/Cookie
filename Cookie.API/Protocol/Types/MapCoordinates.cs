using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MapCoordinates : NetworkType
    {
        public const ushort ProtocolId = 174;

        public override ushort TypeID => ProtocolId;

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public MapCoordinates() { }

        public MapCoordinates( short WorldX, short WorldY ){
            this.WorldX = WorldX;
            this.WorldY = WorldY;
        }

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
