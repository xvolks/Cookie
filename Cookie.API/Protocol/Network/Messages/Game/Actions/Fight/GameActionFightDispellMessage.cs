using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightDispellMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5533;

        public GameActionFightDispellMessage(double targetId)
        {
            TargetId = targetId;
        }

        public GameActionFightDispellMessage()
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