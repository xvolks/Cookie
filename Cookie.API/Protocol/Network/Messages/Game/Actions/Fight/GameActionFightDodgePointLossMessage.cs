using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightDodgePointLossMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5828;

        public GameActionFightDodgePointLossMessage(double targetId, ushort amount)
        {
            TargetId = targetId;
            Amount = amount;
        }

        public GameActionFightDodgePointLossMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public ushort Amount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhShort(Amount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarUhShort();
        }
    }
}