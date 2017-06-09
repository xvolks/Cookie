using Cookie.IO;

namespace Cookie.Protocol.Network.Types.Game.Social
{
    public class AbstractSocialGroupInfos : NetworkType
    {
        public const short ProtocolId = 416;
        public override short TypeID { get { return ProtocolId; } }

        public AbstractSocialGroupInfos() { }

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}
