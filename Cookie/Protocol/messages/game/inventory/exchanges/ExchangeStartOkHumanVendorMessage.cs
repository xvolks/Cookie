using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkHumanVendorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5767;
        public override uint MessageID { get { return ProtocolId; } }

        public double SellerId = 0;
        public List<ObjectItemToSellInHumanVendorShop> ObjectsInfos;

        public ExchangeStartOkHumanVendorMessage()
        {
        }

        public ExchangeStartOkHumanVendorMessage(
            double sellerId,
            List<ObjectItemToSellInHumanVendorShop> objectsInfos
        )
        {
            SellerId = sellerId;
            ObjectsInfos = objectsInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(SellerId);
            writer.WriteShort((short)ObjectsInfos.Count());
            foreach (var current in ObjectsInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SellerId = reader.ReadDouble();
            var countObjectsInfos = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSellInHumanVendorShop>();
            for (short i = 0; i < countObjectsInfos; i++)
            {
                ObjectItemToSellInHumanVendorShop type = new ObjectItemToSellInHumanVendorShop();
                type.Deserialize(reader);
                ObjectsInfos.Add(type);
            }
        }
    }
}