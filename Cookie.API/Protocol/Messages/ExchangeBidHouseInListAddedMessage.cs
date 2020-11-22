using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseInListAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5949;

        public override ushort MessageID => ProtocolId;

        public int ItemUID { get; set; }
        public int ObjGenericId { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public List<long> Prices { get; set; }
        public ExchangeBidHouseInListAddedMessage() { }

        public ExchangeBidHouseInListAddedMessage( int ItemUID, int ObjGenericId, List<ObjectEffect> Effects, List<long> Prices ){
            this.ItemUID = ItemUID;
            this.ObjGenericId = ObjGenericId;
            this.Effects = Effects;
            this.Prices = Prices;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ItemUID);
            writer.WriteInt(ObjGenericId);
			writer.WriteShort((short)Effects.Count);
			foreach (var x in Effects)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Prices.Count);
			foreach (var x in Prices)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemUID = reader.ReadInt();
            ObjGenericId = reader.ReadInt();
            var EffectsCount = reader.ReadShort();
            Effects = new List<ObjectEffect>();
            for (var i = 0; i < EffectsCount; i++)
            {
                ObjectEffect objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            var PricesCount = reader.ReadShort();
            Prices = new List<long>();
            for (var i = 0; i < PricesCount; i++)
            {
                Prices.Add(reader.ReadVarLong());
            }
        }
    }
}
