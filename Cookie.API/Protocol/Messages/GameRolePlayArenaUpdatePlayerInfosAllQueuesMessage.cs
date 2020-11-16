using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
    {
        public new const ushort ProtocolId = 6728;

        public override ushort MessageID => ProtocolId;

        public ArenaRankInfos Team { get; set; }
        public ArenaRankInfos Duel { get; set; }
        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage() { }

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage( ArenaRankInfos Team, ArenaRankInfos Duel ){
            this.Team = Team;
            this.Duel = Duel;
        }

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
