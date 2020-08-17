using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Common
{
    public class NetworkDataContainerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}