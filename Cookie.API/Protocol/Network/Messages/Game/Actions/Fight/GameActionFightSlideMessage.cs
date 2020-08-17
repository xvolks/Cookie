using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightSlideMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5525;

        public GameActionFightSlideMessage(double targetId, short startCellId, short endCellId)
        {
            TargetId = targetId;
            StartCellId = startCellId;
            EndCellId = endCellId;
        }

        public GameActionFightSlideMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public short StartCellId { get; set; }
        public short EndCellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(StartCellId);
            writer.WriteShort(EndCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            StartCellId = reader.ReadShort();
            EndCellId = reader.ReadShort();
        }
    }
}