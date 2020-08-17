using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Fight.Arena;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
    {
        public new const ushort ProtocolId = 6728;

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(ArenaRankInfos team, ArenaRankInfos duel)
        {
            Team = team;
            Duel = duel;
        }

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ArenaRankInfos Team { get; set; }
        public ArenaRankInfos Duel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Team.Serialize(writer);
            Duel.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Team = new ArenaRankInfos();
            Team.Deserialize(reader);
            Duel = new ArenaRankInfos();
            Duel.Deserialize(reader);
        }
    }
}