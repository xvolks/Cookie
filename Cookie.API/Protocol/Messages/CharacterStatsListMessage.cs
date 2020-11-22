using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterStatsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 500;

        public override ushort MessageID => ProtocolId;

        public CharacterCharacteristicsInformations Stats { get; set; }
        public CharacterStatsListMessage() { }

        public CharacterStatsListMessage( CharacterCharacteristicsInformations Stats ){
            this.Stats = Stats;
        }

        public override void Serialize(IDataWriter writer)
        {
            Stats.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Stats = new CharacterCharacteristicsInformations();
            Stats.Deserialize(reader);
        }
    }
}
