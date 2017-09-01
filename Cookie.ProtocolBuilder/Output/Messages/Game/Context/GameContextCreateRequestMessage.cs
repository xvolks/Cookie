namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameContextCreateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 250;
        public override ushort MessageID => ProtocolId;

        public GameContextCreateRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
