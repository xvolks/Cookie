using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFightPlayersEnemiesListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5928;
        public override uint MessageID { get { return ProtocolId; } }

        public double FightId = 0;
        public List<CharacterMinimalPlusLookInformations> PlayerInfo;

        public GuildFightPlayersEnemiesListMessage()
        {
        }

        public GuildFightPlayersEnemiesListMessage(
            double fightId,
            List<CharacterMinimalPlusLookInformations> playerInfo
        )
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteShort((short)PlayerInfo.Count());
            foreach (var current in PlayerInfo)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadDouble();
            var countPlayerInfo = reader.ReadShort();
            PlayerInfo = new List<CharacterMinimalPlusLookInformations>();
            for (short i = 0; i < countPlayerInfo; i++)
            {
                CharacterMinimalPlusLookInformations type = new CharacterMinimalPlusLookInformations();
                type.Deserialize(reader);
                PlayerInfo.Add(type);
            }
        }
    }
}