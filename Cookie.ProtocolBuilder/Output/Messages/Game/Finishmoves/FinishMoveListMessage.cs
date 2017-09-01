namespace Cookie.API.Protocol.Network.Messages.Game.Finishmoves
{
    using Types.Game.Finishmoves;
    using System.Collections.Generic;
    using Utils.IO;

    public class FinishMoveListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6704;
        public override ushort MessageID => ProtocolId;
        public List<FinishMoveInformations> FinishMoves { get; set; }

        public FinishMoveListMessage(List<FinishMoveInformations> finishMoves)
        {
            FinishMoves = finishMoves;
        }

        public FinishMoveListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)FinishMoves.Count);
            for (var finishMovesIndex = 0; finishMovesIndex < FinishMoves.Count; finishMovesIndex++)
            {
                var objectToSend = FinishMoves[finishMovesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var finishMovesCount = reader.ReadUShort();
            FinishMoves = new List<FinishMoveInformations>();
            for (var finishMovesIndex = 0; finishMovesIndex < finishMovesCount; finishMovesIndex++)
            {
                var objectToAdd = new FinishMoveInformations();
                objectToAdd.Deserialize(reader);
                FinishMoves.Add(objectToAdd);
            }
        }

    }
}
