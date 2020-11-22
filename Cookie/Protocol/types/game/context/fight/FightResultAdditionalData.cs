using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultAdditionalData : NetworkType
    {
        public const short ProtocolId = 191;
        public override short TypeId { get { return ProtocolId; } }

        public FightResultAdditionalData()
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