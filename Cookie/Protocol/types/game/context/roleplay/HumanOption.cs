using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOption : NetworkType
    {
        public const short ProtocolId = 406;
        public override short TypeId { get { return ProtocolId; } }

        public HumanOption()
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