using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    public class DownloadGetCurrentSpeedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1510;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}