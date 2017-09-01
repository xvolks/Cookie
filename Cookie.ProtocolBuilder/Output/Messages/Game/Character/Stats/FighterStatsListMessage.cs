namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Types.Game.Character.Characteristic;
    using Utils.IO;

    public class FighterStatsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6322;
        public override ushort MessageID => ProtocolId;
        public CharacterCharacteristicsInformations Stats { get; set; }

        public FighterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            Stats = stats;
        }

        public FighterStatsListMessage() { }

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
