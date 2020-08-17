using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    public class TaxCollectorBasicInformations : NetworkType
    {
        public const ushort ProtocolId = 96;

        public TaxCollectorBasicInformations(ushort firstNameId, ushort lastNameId, short worldX, short worldY,
            int mapId, ushort subAreaId)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public TaxCollectorBasicInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}