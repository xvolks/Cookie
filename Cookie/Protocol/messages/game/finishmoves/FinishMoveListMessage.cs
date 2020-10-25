using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class FinishMoveListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6704;
        public override uint MessageID { get { return ProtocolId; } }

        public List<FinishMoveInformations> FinishMoves;

        public FinishMoveListMessage()
        {
        }

        public FinishMoveListMessage(
            List<FinishMoveInformations> finishMoves
        )
        {
            FinishMoves = finishMoves;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)FinishMoves.Count());
            foreach (var current in FinishMoves)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFinishMoves = reader.ReadShort();
            FinishMoves = new List<FinishMoveInformations>();
            for (short i = 0; i < countFinishMoves; i++)
            {
                FinishMoveInformations type = new FinishMoveInformations();
                type.Deserialize(reader);
                FinishMoves.Add(type);
            }
        }
    }
}