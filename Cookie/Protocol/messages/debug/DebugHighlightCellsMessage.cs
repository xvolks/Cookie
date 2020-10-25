using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DebugHighlightCellsMessage : NetworkMessage
    {
        public const uint ProtocolId = 2001;
        public override uint MessageID { get { return ProtocolId; } }

        public double Color = 0;
        public List<short> Cells;

        public DebugHighlightCellsMessage()
        {
        }

        public DebugHighlightCellsMessage(
            double color,
            List<short> cells
        )
        {
            Color = color;
            Cells = cells;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Color);
            writer.WriteShort((short)Cells.Count());
            foreach (var current in Cells)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Color = reader.ReadDouble();
            var countCells = reader.ReadShort();
            Cells = new List<short>();
            for (short i = 0; i < countCells; i++)
            {
                Cells.Add(reader.ReadVarShort());
            }
        }
    }
}