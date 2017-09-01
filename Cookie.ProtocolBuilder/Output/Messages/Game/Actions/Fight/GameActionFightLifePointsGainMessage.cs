namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6311;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public uint Delta { get; set; }

        public GameActionFightLifePointsGainMessage(double targetId, uint delta)
        {
            TargetId = targetId;
            Delta = delta;
        }

        public GameActionFightLifePointsGainMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(Delta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Delta = reader.ReadVarUhInt();
        }

    }
}
