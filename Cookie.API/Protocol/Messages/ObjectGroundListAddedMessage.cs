using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectGroundListAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5925;

        public override ushort MessageID => ProtocolId;

        public List<short> Cells { get; set; }
        public List<short> ReferenceIds { get; set; }
        public ObjectGroundListAddedMessage() { }

        public ObjectGroundListAddedMessage( List<short> Cells, List<short> ReferenceIds ){
            this.Cells = Cells;
            this.ReferenceIds = ReferenceIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Cells.Count);
			foreach (var x in Cells)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)ReferenceIds.Count);
			foreach (var x in ReferenceIds)
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
            var ReferenceIdsCount = reader.ReadShort();
            ReferenceIds = new List<short>();
            for (var i = 0; i < ReferenceIdsCount; i++)
            {
                ReferenceIds.Add(reader.ReadVarShort());
            }
        }
    }
}
