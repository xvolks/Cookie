using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
    {
        public new const ushort ProtocolId = 352;

        public ObjectItemToSellInNpcShop(ulong objectPrice, string buyCriterion)
        {
            ObjectPrice = objectPrice;
            BuyCriterion = buyCriterion;
        }

        public ObjectItemToSellInNpcShop()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong ObjectPrice { get; set; }
        public string BuyCriterion { get; set; }

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