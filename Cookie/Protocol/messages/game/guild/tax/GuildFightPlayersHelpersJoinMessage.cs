using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
    {
        public const uint ProtocolId = 5720;
        public override uint MessageID { get { return ProtocolId; } }

        public double FightId = 0;
        public CharacterMinimalPlusLookInformations PlayerInfo;

        public GuildFightPlayersHelpersJoinMessage()
        {
        }

        public GuildFightPlayersHelpersJoinMessage(
            double fightId,
            CharacterMinimalPlusLookInformations playerInfo
        )
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(FightId);
            PlayerInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadDouble();
            PlayerInfo = new CharacterMinimalPlusLookInformations();
            PlayerInfo.Deserialize(reader);
        }
    }
}