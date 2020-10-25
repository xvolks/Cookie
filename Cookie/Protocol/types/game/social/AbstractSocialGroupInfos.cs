using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AbstractSocialGroupInfos : NetworkType
    {
        public const short ProtocolId = 416;
        public override short TypeId { get { return ProtocolId; } }

        public AbstractSocialGroupInfos()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}