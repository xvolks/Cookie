using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class AbstractSocialGroupInfos : NetworkType
    {
        public const ushort ProtocolId = 416;

        public override ushort TypeID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}