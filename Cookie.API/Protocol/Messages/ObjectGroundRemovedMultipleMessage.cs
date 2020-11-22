using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectGroundRemovedMultipleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5944;

        public override ushort MessageID => ProtocolId;

        public List<short> Cells { get; set; }
        public ObjectGroundRemovedMultipleMessage() { }

        public ObjectGroundRemovedMultipleMessage( List<short> Cells ){
            this.Cells = Cells;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Cells.Count);
			foreach (var x in Cells)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CellsCount = reader.ReadShort();
            Cells = new List<short>();
            for (var i = 0; i < CellsCount; i++)
            {
                Cells.Add(reader.ReadVarShort());
            }
        }
    }
}
