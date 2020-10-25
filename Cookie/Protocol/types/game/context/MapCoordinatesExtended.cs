using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MapCoordinatesExtended : MapCoordinatesAndId
    {
        public new const short ProtocolId = 176;
        public override short TypeId { get { return ProtocolId; } }

        public short SubAreaId = 0;

        public MapCoordinatesExtended(): base()
        {
        }

        public MapCoordinatesExtended(
            short worldX,
            short worldY,
            double mapId,
            short subAreaId
        ): base(
            worldX,
            worldY,
            mapId
        )
        {
            SubAreaId = subAreaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(SubAreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SubAreaId = reader.ReadVarShort();
        }
    }
}