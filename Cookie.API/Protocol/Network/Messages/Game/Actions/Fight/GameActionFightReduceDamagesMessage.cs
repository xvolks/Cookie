using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5526;

        public GameActionFightReduceDamagesMessage(double targetId, uint amount)
        {
            TargetId = targetId;
            Amount = amount;
        }

        public GameActionFightReduceDamagesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public uint Amount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(Amount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarUhInt();
        }
    }
}