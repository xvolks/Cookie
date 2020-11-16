using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameActionMarkedCell : NetworkType
    {
        public const short ProtocolId = 85;
        public override short TypeId { get { return ProtocolId; } }

        public short CellId = 0;
        public byte ZoneSize = 0;
        public int CellColor = 0;
        public byte CellsType = 0;

        public GameActionMarkedCell()
        {
        }

        public GameActionMarkedCell(
            short cellId,
            byte zoneSize,
            int cellColor,
            byte cellsType
        )
        {
            CellId = cellId;
            ZoneSize = zoneSize;
            CellColor = cellColor;
            CellsType = cellsType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CellId);
            writer.WriteByte(ZoneSize);
            writer.WriteInt(CellColor);
            writer.WriteByte(CellsType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellId = reader.ReadVarShort();
            ZoneSize = reader.ReadByte();
            CellColor = reader.ReadInt();
            CellsType = reader.ReadByte();
        }
    }
}