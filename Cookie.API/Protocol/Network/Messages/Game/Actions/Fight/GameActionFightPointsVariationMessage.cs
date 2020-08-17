using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightPointsVariationMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 1030;

        public GameActionFightPointsVariationMessage(double targetId, short delta)
        {
            TargetId = targetId;
            Delta = delta;
        }

        public GameActionFightPointsVariationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public short Delta { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(Delta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Delta = reader.ReadShort();
        }
    }
}