using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectGroundListAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5925;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Cells;
        public List<short> ReferenceIds;

        public ObjectGroundListAddedMessage()
        {
        }

        public ObjectGroundListAddedMessage(
            List<short> cells,
            List<short> referenceIds
        )
        {
            Cells = cells;
            ReferenceIds = referenceIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Cells.Count());
            foreach (var current in Cells)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)ReferenceIds.Count());
            foreach (var current in ReferenceIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCells = reader.ReadShort();
            Cells = new List<short>();
            for (short i = 0; i < countCells; i++)
            {
                Cells.Add(reader.ReadVarShort());
            }
            var countReferenceIds = reader.ReadShort();
            ReferenceIds = new List<short>();
            for (short i = 0; i < countReferenceIds; i++)
            {
                ReferenceIds.Add(reader.ReadVarShort());
            }
        }
    }
}