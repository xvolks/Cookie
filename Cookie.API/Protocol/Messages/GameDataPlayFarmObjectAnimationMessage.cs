using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6026;

        public override ushort MessageID => ProtocolId;

        public List<short> CellId { get; set; }
        public GameDataPlayFarmObjectAnimationMessage() { }

        public GameDataPlayFarmObjectAnimationMessage( List<short> CellId ){
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)CellId.Count);
			foreach (var x in CellId)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CellIdCount = reader.ReadShort();
            CellId = new List<short>();
            for (var i = 0; i < CellIdCount; i++)
            {
                CellId.Add(reader.ReadVarShort());
            }
        }
    }
}
