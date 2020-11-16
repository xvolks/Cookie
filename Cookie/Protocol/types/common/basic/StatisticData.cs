using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatisticData : NetworkType
    {
        public const short ProtocolId = 484;
        public override short TypeId { get { return ProtocolId; } }

        public StatisticData()
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