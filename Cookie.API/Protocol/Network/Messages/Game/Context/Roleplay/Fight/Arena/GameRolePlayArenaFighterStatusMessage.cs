using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaFighterStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6281;

        public GameRolePlayArenaFighterStatusMessage(int fightId, int playerId, bool accepted)
        {
            FightId = fightId;
            PlayerId = playerId;
            Accepted = accepted;
        }

        public GameRolePlayArenaFighterStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public int PlayerId { get; set; }
        public bool Accepted { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteInt(PlayerId);
            writer.WriteBoolean(Accepted);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            PlayerId = reader.ReadInt();
            Accepted = reader.ReadBoolean();
        }
    }
}