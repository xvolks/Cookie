using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FighterStatsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6322;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterCharacteristicsInformations Stats;

        public FighterStatsListMessage()
        {
        }

        public FighterStatsListMessage(
            CharacterCharacteristicsInformations stats
        )
        {
            Stats = stats;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Stats.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Stats = new CharacterCharacteristicsInformations();
            Stats.Deserialize(reader);
        }
    }
}