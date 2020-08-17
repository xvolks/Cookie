using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5720;

        public GuildFightPlayersHelpersJoinMessage(int fightId, CharacterMinimalPlusLookInformations playerInfo)
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }

        public GuildFightPlayersHelpersJoinMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public CharacterMinimalPlusLookInformations PlayerInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            PlayerInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            PlayerInfo = new CharacterMinimalPlusLookInformations();
            PlayerInfo.Deserialize(reader);
        }
    }
}