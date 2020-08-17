using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class GameActionMarkedCell : NetworkType
    {
        public const ushort ProtocolId = 85;

        public GameActionMarkedCell(ushort cellId, sbyte zoneSize, int cellColor, sbyte cellsType)
        {
            CellId = cellId;
            ZoneSize = zoneSize;
            CellColor = cellColor;
            CellsType = cellsType;
        }

        public GameActionMarkedCell()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort CellId { get; set; }
        public sbyte ZoneSize { get; set; }
        public int CellColor { get; set; }
        public sbyte CellsType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteSByte(ZoneSize);
            writer.WriteInt(CellColor);
            writer.WriteSByte(CellsType);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            ZoneSize = reader.ReadSByte();
            CellColor = reader.ReadInt();
            CellsType = reader.ReadSByte();
        }
    }
}