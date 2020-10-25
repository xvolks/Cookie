using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
    {
        public new const short ProtocolId = 434;
        public override short TypeId { get { return ProtocolId; } }

        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public PrismInformation Prism;

        public PrismGeolocalizedInformation(): base()
        {
        }

        public PrismGeolocalizedInformation(
            short subAreaId,
            int allianceId,
            short worldX,
            short worldY,
            double mapId,
            PrismInformation prism
        ): base(
            subAreaId,
            allianceId
        )
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            Prism = prism;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteShort(Prism.TypeId);
            Prism.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            var prismTypeId = reader.ReadShort();
            Prism = new PrismInformation();
            Prism.Deserialize(reader);
        }
    }
}