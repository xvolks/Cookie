using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6026;

        public GameDataPlayFarmObjectAnimationMessage(List<ushort> cellId)
        {
            CellId = cellId;
        }

        public GameDataPlayFarmObjectAnimationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) CellId.Count);
            for (var cellIdIndex = 0; cellIdIndex < CellId.Count; cellIdIndex++)
                writer.WriteVarUhShort(CellId[cellIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var cellIdCount = reader.ReadUShort();
            CellId = new List<ushort>();
            for (var cellIdIndex = 0; cellIdIndex < cellIdCount; cellIdIndex++)
                CellId.Add(reader.ReadVarUhShort());
        }
    }
}