using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FinishMoveListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6704;

        public override ushort MessageID => ProtocolId;

        public List<FinishMoveInformations> FinishMoves { get; set; }
        public FinishMoveListMessage() { }

        public FinishMoveListMessage( List<FinishMoveInformations> FinishMoves ){
            this.FinishMoves = FinishMoves;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)FinishMoves.Count);
			foreach (var x in FinishMoves)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FinishMovesCount = reader.ReadShort();
            FinishMoves = new List<FinishMoveInformations>();
            for (var i = 0; i < FinishMovesCount; i++)
            {
                var objectToAdd = new FinishMoveInformations();
                objectToAdd.Deserialize(reader);
                FinishMoves.Add(objectToAdd);
            }
        }
    }
}
