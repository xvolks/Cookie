namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5527;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public short CasterCellId { get; set; }
        public short TargetCellId { get; set; }

        public GameActionFightExchangePositionsMessage(double targetId, short casterCellId, short targetCellId)
        {
            TargetId = targetId;
            CasterCellId = casterCellId;
            TargetCellId = targetCellId;
        }

        public GameActionFightExchangePositionsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(CasterCellId);
            writer.WriteShort(TargetCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            CasterCellId = reader.ReadShort();
            TargetCellId = reader.ReadShort();
        }

    }
}
