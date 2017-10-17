using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
    {
        public new const ushort ProtocolId = 434;

        public PrismGeolocalizedInformation(short worldX, short worldY, double mapId, PrismInformation prism)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            Prism = prism;
        }

        public PrismGeolocalizedInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public PrismInformation Prism { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteUShort(Prism.TypeID);
            Prism.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            Prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadUShort());
            Prism.Deserialize(reader);
        }
    }
}