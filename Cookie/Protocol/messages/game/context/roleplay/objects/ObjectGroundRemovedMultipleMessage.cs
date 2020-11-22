using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectGroundRemovedMultipleMessage : NetworkMessage
    {
        public const uint ProtocolId = 5944;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Cells;

        public ObjectGroundRemovedMultipleMessage()
        {
        }

        public ObjectGroundRemovedMultipleMessage(
            List<short> cells
        )
        {
            Cells = cells;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Cells.Count());
            foreach (var current in Cells)
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
        }
    }
}