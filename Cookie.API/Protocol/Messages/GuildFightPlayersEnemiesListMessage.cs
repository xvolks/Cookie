using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFightPlayersEnemiesListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5928;

        public override ushort MessageID => ProtocolId;

        public double FightId { get; set; }
        public List<CharacterMinimalPlusLookInformations> PlayerInfo { get; set; }
        public GuildFightPlayersEnemiesListMessage() { }

        public GuildFightPlayersEnemiesListMessage( double FightId, List<CharacterMinimalPlusLookInformations> PlayerInfo ){
            this.FightId = FightId;
            this.PlayerInfo = PlayerInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
			writer.WriteShort((short)PlayerInfo.Count);
			foreach (var x in PlayerInfo)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            var PlayerInfoCount = reader.ReadShort();
            PlayerInfo = new List<CharacterMinimalPlusLookInformations>();
            for (var i = 0; i < PlayerInfoCount; i++)
            {
                var objectToAdd = new CharacterMinimalPlusLookInformations();
                objectToAdd.Deserialize(reader);
                PlayerInfo.Add(objectToAdd);
            }
        }
    }
}
