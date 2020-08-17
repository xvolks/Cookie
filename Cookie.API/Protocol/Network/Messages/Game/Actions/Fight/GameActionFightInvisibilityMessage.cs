using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5821;

        public GameActionFightInvisibilityMessage(double targetId, byte state)
        {
            TargetId = targetId;
            State = state;
        }

        public GameActionFightInvisibilityMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public byte State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            State = reader.ReadByte();
        }
    }
}