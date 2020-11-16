using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockBuyableInformations : NetworkType
    {
        public const ushort ProtocolId = 130;

        public override ushort TypeID => ProtocolId;

        public ulong Price { get; set; }
        public bool Locked { get; set; }
        public PaddockBuyableInformations() { }

        public PaddockBuyableInformations( ulong Price, bool Locked ){
            this.Price = Price;
            this.Locked = Locked;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Price);
            writer.WriteBoolean(Locked);
        }

        public override void Deserialize(IDataReader reader)
        {
            Price = reader.ReadVarUhLong();
            Locked = reader.ReadBoolean();
        }
    }
}
