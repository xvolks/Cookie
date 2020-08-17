namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameContextDestroyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 201;
        public override ushort MessageID => ProtocolId;

        public GameContextDestroyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
