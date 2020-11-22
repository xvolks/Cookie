using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorBasicInformations : NetworkType
    {
        public const short ProtocolId = 96;
        public override short TypeId { get { return ProtocolId; } }

        public short FirstNameId = 0;
        public short LastNameId = 0;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;

        public TaxCollectorBasicInformations()
        {
        }

        public TaxCollectorBasicInformations(
            short firstNameId,
            short lastNameId,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId
        )
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FirstNameId);
            writer.WriteVarShort(LastNameId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FirstNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
        }
    }
}