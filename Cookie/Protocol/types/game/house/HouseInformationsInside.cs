using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HouseInformationsInside : HouseInformations
    {
        public new const short ProtocolId = 218;
        public override short TypeId { get { return ProtocolId; } }

        public HouseInstanceInformations HouseInfos;
        public short WorldX = 0;
        public short WorldY = 0;

        public HouseInformationsInside(): base()
        {
        }

        public HouseInformationsInside(
            int houseId,
            short modelId,
            HouseInstanceInformations houseInfos,
            short worldX,
            short worldY
        ): base(
            houseId,
            modelId
        )
        {
            HouseInfos = houseInfos;
            WorldX = worldX;
            WorldY = worldY;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(HouseInfos.TypeId);
            HouseInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var houseInfosTypeId = reader.ReadShort();
            HouseInfos = new HouseInstanceInformations();
            HouseInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}