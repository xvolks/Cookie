using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AccountHouseInformations : HouseInformations
    {
        public new const short ProtocolId = 390;
        public override short TypeId { get { return ProtocolId; } }

        public HouseInstanceInformations HouseInfos;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;

        public AccountHouseInformations(): base()
        {
        }

        public AccountHouseInformations(
            int houseId,
            short modelId,
            HouseInstanceInformations houseInfos,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId
        ): base(
            houseId,
            modelId
        )
        {
            HouseInfos = houseInfos;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(HouseInfos.TypeId);
            HouseInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var houseInfosTypeId = reader.ReadShort();
            HouseInfos = new HouseInstanceInformations();
            HouseInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
        }
    }
}