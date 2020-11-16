using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntStep : NetworkType
    {
        public const short ProtocolId = 463;
        public override short TypeId { get { return ProtocolId; } }

        public TreasureHuntStep()
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