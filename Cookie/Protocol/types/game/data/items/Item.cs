using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class Item : NetworkType
    {
        public const short ProtocolId = 7;
        public override short TypeId { get { return ProtocolId; } }

        public Item()
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