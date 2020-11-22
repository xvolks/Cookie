using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DebugHighlightCellsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2001;

        public override ushort MessageID => ProtocolId;

        public double Color { get; set; }
        public List<short> Cells { get; set; }
        public DebugHighlightCellsMessage() { }

        public DebugHighlightCellsMessage( double Color, List<short> Cells ){
            this.Color = Color;
            this.Cells = Cells;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Color);
			writer.WriteShort((short)Cells.Count);
			foreach (var x in Cells)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Color = reader.ReadDouble();
            var CellsCount = reader.ReadShort();
            Cells = new List<short>();
            for (var i = 0; i < CellsCount; i++)
            {
                Cells.Add(reader.ReadVarShort());
            }
        }
    }
}
