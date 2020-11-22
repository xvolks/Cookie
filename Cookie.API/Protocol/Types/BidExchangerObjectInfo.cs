using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class BidExchangerObjectInfo : NetworkType
    {
        public const ushort ProtocolId = 122;

        public override ushort TypeID => ProtocolId;

        public uint ObjectUID { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public List<long> Prices { get; set; }
        public BidExchangerObjectInfo() { }

        public BidExchangerObjectInfo( uint ObjectUID, List<ObjectEffect> Effects, List<long> Prices ){
            this.ObjectUID = ObjectUID;
            this.Effects = Effects;
            this.Prices = Prices;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
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
            ObjectUID = reader.ReadVarUhInt();
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
