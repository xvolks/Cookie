using Cookie.API.Protocol.Network.Types.Game.Character.Characteristic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    public class CharacterStatsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 500;

        public CharacterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            Stats = stats;
        }

        public CharacterStatsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public CharacterCharacteristicsInformations Stats { get; set; }

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