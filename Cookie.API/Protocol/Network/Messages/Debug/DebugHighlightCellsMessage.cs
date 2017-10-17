using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Debug
{
    public class DebugHighlightCellsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2001;

        public DebugHighlightCellsMessage(double color, List<ushort> cells)
        {
            Color = color;
            Cells = cells;
        }

        public DebugHighlightCellsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double Color { get; set; }
        public List<ushort> Cells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Color);
            writer.WriteShort((short) Cells.Count);
            for (var cellsIndex = 0; cellsIndex < Cells.Count; cellsIndex++)
                writer.WriteVarUhShort(Cells[cellsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Color = reader.ReadDouble();
            var cellsCount = reader.ReadUShort();
            Cells = new List<ushort>();
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
                Cells.Add(reader.ReadVarUhShort());
        }
    }
}