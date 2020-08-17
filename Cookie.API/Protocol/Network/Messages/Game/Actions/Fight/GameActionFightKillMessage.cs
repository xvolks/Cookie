using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightKillMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5571;

        public GameActionFightKillMessage(double targetId)
        {
            TargetId = targetId;
        }

        public GameActionFightKillMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
        }
    }
}