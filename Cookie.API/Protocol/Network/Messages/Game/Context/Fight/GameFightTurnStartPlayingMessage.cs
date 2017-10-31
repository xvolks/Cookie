namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTurnStartPlayingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6465;
        public override ushort MessageID => ProtocolId;

        public GameFightTurnStartPlayingMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
