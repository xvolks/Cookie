namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameContextCreateErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6024;
        public override ushort MessageID => ProtocolId;

        public GameContextCreateErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
