namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightStealKamaMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5535;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public ulong Amount { get; set; }

        public GameActionFightStealKamaMessage(double targetId, ulong amount)
        {
            TargetId = targetId;
            Amount = amount;
        }

        public GameActionFightStealKamaMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhLong(Amount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarUhLong();
        }

    }
}
