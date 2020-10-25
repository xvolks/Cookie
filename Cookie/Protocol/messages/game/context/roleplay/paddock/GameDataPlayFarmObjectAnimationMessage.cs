using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6026;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> CellId;

        public GameDataPlayFarmObjectAnimationMessage()
        {
        }

        public GameDataPlayFarmObjectAnimationMessage(
            List<short> cellId
        )
        {
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)CellId.Count());
            foreach (var current in CellId)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCellId = reader.ReadShort();
            CellId = new List<short>();
            for (short i = 0; i < countCellId; i++)
            {
                CellId.Add(reader.ReadVarShort());
            }
        }
    }
}