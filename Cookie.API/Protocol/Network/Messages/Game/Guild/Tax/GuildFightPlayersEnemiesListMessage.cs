using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersEnemiesListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5928;

        public GuildFightPlayersEnemiesListMessage(double fightId,
            List<CharacterMinimalPlusLookInformations> playerInfo)
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }

        public GuildFightPlayersEnemiesListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double FightId { get; set; }
        public List<CharacterMinimalPlusLookInformations> PlayerInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteShort((short) PlayerInfo.Count);
            for (var playerInfoIndex = 0; playerInfoIndex < PlayerInfo.Count; playerInfoIndex++)
            {
                var objectToSend = PlayerInfo[playerInfoIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            var playerInfoCount = reader.ReadUShort();
            PlayerInfo = new List<CharacterMinimalPlusLookInformations>();
            for (var playerInfoIndex = 0; playerInfoIndex < playerInfoCount; playerInfoIndex++)
            {
                var objectToAdd = new CharacterMinimalPlusLookInformations();
                objectToAdd.Deserialize(reader);
                PlayerInfo.Add(objectToAdd);
            }
        }
    }
}