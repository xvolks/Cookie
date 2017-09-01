using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    public class KrosmasterAuthTokenRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6346;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}