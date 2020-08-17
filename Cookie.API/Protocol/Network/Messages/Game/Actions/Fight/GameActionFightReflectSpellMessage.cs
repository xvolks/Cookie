using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightReflectSpellMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5531;

        public GameActionFightReflectSpellMessage(double targetId)
        {
            TargetId = targetId;
        }

        public GameActionFightReflectSpellMessage()
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