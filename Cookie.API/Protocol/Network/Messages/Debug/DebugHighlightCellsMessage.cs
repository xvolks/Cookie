using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Debug
{
    public class DebugHighlightCellsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2001;

        public DebugHighlightCellsMessage(int color, List<ushort> cells)
        {
            Color = color;
            Cells = cells;
        }

        public DebugHighlightCellsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int Color { get; set; }
        public List<ushort> Cells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Color);
            writer.WriteShort((short) Cells.Count);
            for (var cellsIndex = 0; cellsIndex < Cells.Count; cellsIndex++)
                writer.WriteVarUhShort(Cells[cellsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Color = reader.ReadInt();
            var cellsCount = reader.ReadUShort();
            Cells = new List<ushort>();
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
                Cells.Add(reader.ReadVarUhShort());
        }
    }
}