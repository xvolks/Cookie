using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.House
{
    public class AccountHouseInformations : HouseInformations
    {
        public new const ushort ProtocolId = 390;

        public AccountHouseInformations(HouseInstanceInformations houseInfos, short worldX, short worldY, double mapId,
            ushort subAreaId)
        {
            HouseInfos = houseInfos;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public AccountHouseInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public HouseInstanceInformations HouseInfos { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(HouseInfos.TypeID);
            HouseInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HouseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadUShort());
            HouseInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}