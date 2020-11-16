using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MapCoordinatesAndId : MapCoordinates
    {
        public new const ushort ProtocolId = 392;

        public override ushort TypeID => ProtocolId;

        public double MapId { get; set; }
        public MapCoordinatesAndId() { }

        public MapCoordinatesAndId( double MapId ){
            this.MapId = MapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadDouble();
        }
    }
}
