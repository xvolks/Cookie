namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6312;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public uint Loss { get; set; }
        public uint PermanentDamages { get; set; }

        public GameActionFightLifePointsLostMessage(double targetId, uint loss, uint permanentDamages)
        {
            TargetId = targetId;
            Loss = loss;
            PermanentDamages = permanentDamages;
        }

        public GameActionFightLifePointsLostMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(Loss);
            writer.WriteVarUhInt(PermanentDamages);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Loss = reader.ReadVarUhInt();
            PermanentDamages = reader.ReadVarUhInt();
        }

    }
}
