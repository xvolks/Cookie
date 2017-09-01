using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayPlayerFightFriendlyRequestedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5937;

        public GameRolePlayPlayerFightFriendlyRequestedMessage(int fightId, ulong sourceId, ulong targetId)
        {
            FightId = fightId;
            SourceId = sourceId;
            TargetId = targetId;
        }

        public GameRolePlayPlayerFightFriendlyRequestedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public ulong SourceId { get; set; }
        public ulong TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteVarUhLong(SourceId);
            writer.WriteVarUhLong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            SourceId = reader.ReadVarUhLong();
            TargetId = reader.ReadVarUhLong();
        }
    }
}