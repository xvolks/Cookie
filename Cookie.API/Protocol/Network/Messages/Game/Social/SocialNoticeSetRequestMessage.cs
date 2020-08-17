using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    public class SocialNoticeSetRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6686;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}