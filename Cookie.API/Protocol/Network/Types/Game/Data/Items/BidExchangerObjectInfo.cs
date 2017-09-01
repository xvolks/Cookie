using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    public class BidExchangerObjectInfo : NetworkType
    {
        public const ushort ProtocolId = 122;

        public BidExchangerObjectInfo(uint objectUID, List<ObjectEffect> effects, List<ulong> prices)
        {
            ObjectUID = objectUID;
            Effects = effects;
            Prices = prices;
        }

        public BidExchangerObjectInfo()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint ObjectUID { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public List<ulong> Prices { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
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
            ObjectUID = reader.ReadVarUhInt();
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