namespace Cookie.API.Protocol.Network.Messages.Common
{
    using Utils.IO;

    public class NetworkDataContainerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2;
        public override ushort MessageID => ProtocolId;

        public NetworkDataContainerMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
