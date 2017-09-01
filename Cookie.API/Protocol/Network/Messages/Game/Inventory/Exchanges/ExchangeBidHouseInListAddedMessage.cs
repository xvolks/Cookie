using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseInListAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5949;

        public ExchangeBidHouseInListAddedMessage(int itemUID, int objGenericId, List<ObjectEffect> effects,
            List<ulong> prices)
        {
            ItemUID = itemUID;
            ObjGenericId = objGenericId;
            Effects = effects;
            Prices = prices;
        }

        public ExchangeBidHouseInListAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int ItemUID { get; set; }
        public int ObjGenericId { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public List<ulong> Prices { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ItemUID);
            writer.WriteInt(ObjGenericId);
            writer.WriteShort((short) Effects.Count);
            for (var effectsIndex = 0; effectsIndex < Effects.Count; effectsIndex++)
            {
                var objectToSend = Effects[effectsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Prices.Count);
            for (var pricesIndex = 0; pricesIndex < Prices.Count; pricesIndex++)
                writer.WriteVarUhLong(Prices[pricesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemUID = reader.ReadInt();
            ObjGenericId = reader.ReadInt();
            var effectsCount = reader.ReadUShort();
            Effects = new List<ObjectEffect>();
            for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            var pricesCount = reader.ReadUShort();
            Prices = new List<ulong>();
            for (var pricesIndex = 0; pricesIndex < pricesCount; pricesIndex++)
                Prices.Add(reader.ReadVarUhLong());
        }
    }
}