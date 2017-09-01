namespace Cookie.API.Protocol.Network.Types.Game.Finishmoves
{
    using Utils.IO;

    public class FinishMoveInformations : NetworkType
    {
        public const ushort ProtocolId = 506;
        public override ushort TypeID => ProtocolId;
        public int FinishMoveId { get; set; }
        public bool FinishMoveState { get; set; }

        public FinishMoveInformations(int finishMoveId, bool finishMoveState)
        {
            FinishMoveId = finishMoveId;
            FinishMoveState = finishMoveState;
        }

        public FinishMoveInformations() { }

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
