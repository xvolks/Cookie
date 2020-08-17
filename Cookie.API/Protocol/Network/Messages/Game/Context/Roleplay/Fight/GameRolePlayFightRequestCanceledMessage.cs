using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayFightRequestCanceledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5822;

        public GameRolePlayFightRequestCanceledMessage(int fightId, double sourceId, double targetId)
        {
            FightId = fightId;
            SourceId = sourceId;
            TargetId = targetId;
        }

        public GameRolePlayFightRequestCanceledMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public double SourceId { get; set; }
        public double TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteDouble(SourceId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            SourceId = reader.ReadDouble();
            TargetId = reader.ReadDouble();
        }
    }
}