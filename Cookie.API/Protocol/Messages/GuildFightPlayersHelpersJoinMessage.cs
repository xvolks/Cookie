using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5720;

        public override ushort MessageID => ProtocolId;

        public double FightId { get; set; }
        public CharacterMinimalPlusLookInformations PlayerInfo { get; set; }
        public GuildFightPlayersHelpersJoinMessage() { }

        public GuildFightPlayersHelpersJoinMessage( double FightId, CharacterMinimalPlusLookInformations PlayerInfo ){
            this.FightId = FightId;
            this.PlayerInfo = PlayerInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
            PlayerInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            PlayerInfo = new CharacterMinimalPlusLookInformations();
            PlayerInfo.Deserialize(reader);
        }
    }
}
