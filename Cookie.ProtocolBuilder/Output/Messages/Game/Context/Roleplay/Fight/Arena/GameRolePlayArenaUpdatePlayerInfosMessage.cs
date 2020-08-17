namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    using Types.Game.Context.Roleplay.Fight.Arena;
    using Utils.IO;

    public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6301;
        public override ushort MessageID => ProtocolId;
        public ArenaRankInfos Solo { get; set; }

        public GameRolePlayArenaUpdatePlayerInfosMessage(ArenaRankInfos solo)
        {
            Solo = solo;
        }

        public GameRolePlayArenaUpdatePlayerInfosMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Solo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Solo = new ArenaRankInfos();
            Solo.Deserialize(reader);
        }

    }
}
