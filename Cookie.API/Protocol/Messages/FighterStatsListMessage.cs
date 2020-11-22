using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FighterStatsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6322;

        public override ushort MessageID => ProtocolId;

        public CharacterCharacteristicsInformations Stats { get; set; }
        public FighterStatsListMessage() { }

        public FighterStatsListMessage( CharacterCharacteristicsInformations Stats ){
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
