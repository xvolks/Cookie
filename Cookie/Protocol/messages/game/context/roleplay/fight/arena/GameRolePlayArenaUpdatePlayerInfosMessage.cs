using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
    {
        public const uint ProtocolId = 6301;
        public override uint MessageID { get { return ProtocolId; } }

        public ArenaRankInfos Solo;

        public GameRolePlayArenaUpdatePlayerInfosMessage()
        {
        }

        public GameRolePlayArenaUpdatePlayerInfosMessage(
            ArenaRankInfos solo
        )
        {
            Solo = solo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Solo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Solo = new ArenaRankInfos();
            Solo.Deserialize(reader);
        }
    }
}