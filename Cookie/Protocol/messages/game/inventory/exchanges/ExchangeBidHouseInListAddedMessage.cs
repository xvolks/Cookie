using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseInListAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5949;
        public override uint MessageID { get { return ProtocolId; } }

        public int ItemUID = 0;
        public int ObjGenericId = 0;
        public List<ObjectEffect> Effects;
        public List<long> Prices;

        public ExchangeBidHouseInListAddedMessage()
        {
        }

        public ExchangeBidHouseInListAddedMessage(
            int itemUID,
            int objGenericId,
            List<ObjectEffect> effects,
            List<long> prices
        )
        {
            ItemUID = itemUID;
            ObjGenericId = objGenericId;
            Effects = effects;
            Prices = prices;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(ItemUID);
            writer.WriteInt(ObjGenericId);
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
            ItemUID = reader.ReadInt();
            ObjGenericId = reader.ReadInt();
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