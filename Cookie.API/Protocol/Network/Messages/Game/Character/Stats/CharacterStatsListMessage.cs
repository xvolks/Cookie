namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Types.Game.Character.Characteristic;
    using Utils.IO;

    public class CharacterStatsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 500;
        public override ushort MessageID => ProtocolId;
        public CharacterCharacteristicsInformations Stats { get; set; }

        public CharacterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            Stats = stats;
        }

        public CharacterStatsListMessage() { }

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
