using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MapCoordinatesAndId : MapCoordinates
    {
        public new const short ProtocolId = 392;
        public override short TypeId { get { return ProtocolId; } }

        public double MapId = 0;

        public MapCoordinatesAndId(): base()
        {
        }

        public MapCoordinatesAndId(
            short worldX,
            short worldY,
            double mapId
        ): base(
            worldX,
            worldY
        )
        {
            MapId = mapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadDouble();
        }
    }
}