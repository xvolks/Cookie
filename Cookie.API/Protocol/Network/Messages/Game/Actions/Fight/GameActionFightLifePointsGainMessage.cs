using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6311;

        public GameActionFightLifePointsGainMessage(double targetId, uint delta)
        {
            TargetId = targetId;
            Delta = delta;
        }

        public GameActionFightLifePointsGainMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public uint Delta { get; set; }

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