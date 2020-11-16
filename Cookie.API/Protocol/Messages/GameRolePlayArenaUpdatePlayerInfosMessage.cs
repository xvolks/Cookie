using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6301;

        public override ushort MessageID => ProtocolId;

        public ArenaRankInfos Solo { get; set; }
        public GameRolePlayArenaUpdatePlayerInfosMessage() { }

        public GameRolePlayArenaUpdatePlayerInfosMessage( ArenaRankInfos Solo ){
            this.Solo = Solo;
        }

        public override void Serialize(IDataWriter writer)
        {
            Solo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Solo = new ArenaRankInfos();
            Solo.Deserialize(reader);
        }
    }
}
