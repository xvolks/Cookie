using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
    {
        public new const ushort ProtocolId = 352;

        public override ushort TypeID => ProtocolId;

        public ulong ObjectPrice { get; set; }
        public string BuyCriterion { get; set; }
        public ObjectItemToSellInNpcShop() { }

        public ObjectItemToSellInNpcShop( ulong ObjectPrice, string BuyCriterion ){
            this.ObjectPrice = ObjectPrice;
            this.BuyCriterion = BuyCriterion;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(ObjectPrice);
            writer.WriteUTF(BuyCriterion);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectPrice = reader.ReadVarUhLong();
            BuyCriterion = reader.ReadUTF();
        }
    }
}
