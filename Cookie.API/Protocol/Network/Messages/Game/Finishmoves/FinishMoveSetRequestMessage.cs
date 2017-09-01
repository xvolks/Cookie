using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Finishmoves
{
    public class FinishMoveSetRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6703;

        public FinishMoveSetRequestMessage(int finishMoveId, bool finishMoveState)
        {
            FinishMoveId = finishMoveId;
            FinishMoveState = finishMoveState;
        }

        public FinishMoveSetRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FinishMoveId { get; set; }
        public bool FinishMoveState { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FinishMoveId);
            writer.WriteBoolean(FinishMoveState);
        }

        public override void Deserialize(IDataReader reader)
        {
            FinishMoveId = reader.ReadInt();
            FinishMoveState = reader.ReadBoolean();
        }
    }
}