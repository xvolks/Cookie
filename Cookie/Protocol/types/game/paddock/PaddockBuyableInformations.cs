using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockBuyableInformations : NetworkType
    {
        public const short ProtocolId = 130;
        public override short TypeId { get { return ProtocolId; } }

        public long Price = 0;
        public bool Locked = false;

        public PaddockBuyableInformations()
        {
        }

        public PaddockBuyableInformations(
            long price,
            bool locked
        )
        {
            Price = price;
            Locked = locked;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Price);
            writer.WriteBoolean(Locked);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Price = reader.ReadVarLong();
            Locked = reader.ReadBoolean();
        }
    }
}