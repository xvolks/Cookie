namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    using Types.Game.Data.Items.Effects;
    using System.Collections.Generic;
    using Utils.IO;

    public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
    {
        public new const ushort ProtocolId = 352;
        public override ushort TypeID => ProtocolId;
        public ulong ObjectPrice { get; set; }
        public string BuyCriterion { get; set; }

        public ObjectItemToSellInNpcShop(ulong objectPrice, string buyCriterion)
        {
            ObjectPrice = objectPrice;
            BuyCriterion = buyCriterion;
        }

        public ObjectItemToSellInNpcShop() { }

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
