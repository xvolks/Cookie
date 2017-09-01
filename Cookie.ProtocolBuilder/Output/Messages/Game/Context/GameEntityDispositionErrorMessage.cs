namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameEntityDispositionErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5695;
        public override ushort MessageID => ProtocolId;

        public GameEntityDispositionErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
