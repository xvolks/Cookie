namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightCarryCharacterMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5830;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public short CellId { get; set; }

        public GameActionFightCarryCharacterMessage(double targetId, short cellId)
        {
            TargetId = targetId;
            CellId = cellId;
        }

        public GameActionFightCarryCharacterMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            CellId = reader.ReadShort();
        }

    }
}
