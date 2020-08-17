namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Types.Game.Character;
    using Utils.IO;

    public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5720;
        public override ushort MessageID => ProtocolId;
        public double FightId { get; set; }
        public CharacterMinimalPlusLookInformations PlayerInfo { get; set; }

        public GuildFightPlayersHelpersJoinMessage(double fightId, CharacterMinimalPlusLookInformations playerInfo)
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }

        public GuildFightPlayersHelpersJoinMessage() { }

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
