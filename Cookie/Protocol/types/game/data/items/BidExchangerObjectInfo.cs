using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class BidExchangerObjectInfo : NetworkType
    {
        public const short ProtocolId = 122;
        public override short TypeId { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public List<ObjectEffect> Effects;
        public List<long> Prices;

        public BidExchangerObjectInfo()
        {
        }

        public BidExchangerObjectInfo(
            int objectUID,
            List<ObjectEffect> effects,
            List<long> prices
        )
        {
            ObjectUID = objectUID;
            Effects = effects;
            Prices = prices;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteShort((short)Effects.Count());
            foreach (var current in Effects)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)Prices.Count());
            foreach (var current in Prices)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            var countEffects = reader.ReadShort();
            Effects = new List<ObjectEffect>();
            for (short i = 0; i < countEffects; i++)
            {
                var effectstypeId = reader.ReadShort();
                ObjectEffect type = new ObjectEffect();
                type.Deserialize(reader);
                Effects.Add(type);
            }
            var countPrices = reader.ReadShort();
            Prices = new List<long>();
            for (short i = 0; i < countPrices; i++)
            {
                Prices.Add(reader.ReadVarLong());
            }
        }
    }
}