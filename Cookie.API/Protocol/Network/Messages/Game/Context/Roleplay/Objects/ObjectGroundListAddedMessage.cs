using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Objects
{
    public class ObjectGroundListAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5925;

        public ObjectGroundListAddedMessage(List<ushort> cells, List<ushort> referenceIds)
        {
            Cells = cells;
            ReferenceIds = referenceIds;
        }

        public ObjectGroundListAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> Cells { get; set; }
        public List<ushort> ReferenceIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Cells.Count);
            for (var cellsIndex = 0; cellsIndex < Cells.Count; cellsIndex++)
                writer.WriteVarUhShort(Cells[cellsIndex]);
            writer.WriteShort((short) ReferenceIds.Count);
            for (var referenceIdsIndex = 0; referenceIdsIndex < ReferenceIds.Count; referenceIdsIndex++)
                writer.WriteVarUhShort(ReferenceIds[referenceIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var cellsCount = reader.ReadUShort();
            Cells = new List<ushort>();
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
                Cells.Add(reader.ReadVarUhShort());
            var referenceIdsCount = reader.ReadUShort();
            ReferenceIds = new List<ushort>();
            for (var referenceIdsIndex = 0; referenceIdsIndex < referenceIdsCount; referenceIdsIndex++)
                ReferenceIds.Add(reader.ReadVarUhShort());
        }
    }
}