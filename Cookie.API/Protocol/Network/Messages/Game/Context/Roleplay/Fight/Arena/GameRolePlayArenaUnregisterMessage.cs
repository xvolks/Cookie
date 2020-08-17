namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    using Utils.IO;

    public class GameRolePlayArenaUnregisterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6282;
        public override ushort MessageID => ProtocolId;

        public GameRolePlayArenaUnregisterMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
