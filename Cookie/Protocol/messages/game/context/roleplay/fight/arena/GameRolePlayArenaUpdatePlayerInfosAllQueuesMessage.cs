using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
    {
        public new const uint ProtocolId = 6728;
        public override uint MessageID { get { return ProtocolId; } }

        public ArenaRankInfos Team;
        public ArenaRankInfos Duel;

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(): base()
        {
        }

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(
            ArenaRankInfos solo,
            ArenaRankInfos team,
            ArenaRankInfos duel
        ): base(
            solo
        )
        {
            Team = team;
            Duel = duel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Team.Serialize(writer);
            Duel.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Team = new ArenaRankInfos();
            Team.Deserialize(reader);
            Duel = new ArenaRankInfos();
            Duel.Deserialize(reader);
        }
    }
}