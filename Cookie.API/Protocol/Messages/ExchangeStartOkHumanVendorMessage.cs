using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkHumanVendorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5767;

        public override ushort MessageID => ProtocolId;

        public double SellerId { get; set; }
        public List<ObjectItemToSellInHumanVendorShop> ObjectsInfos { get; set; }
        public ExchangeStartOkHumanVendorMessage() { }

        public ExchangeStartOkHumanVendorMessage( double SellerId, List<ObjectItemToSellInHumanVendorShop> ObjectsInfos ){
            this.SellerId = SellerId;
            this.ObjectsInfos = ObjectsInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SellerId);
			writer.WriteShort((short)ObjectsInfos.Count);
			foreach (var x in ObjectsInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerId = reader.ReadDouble();
            var ObjectsInfosCount = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSellInHumanVendorShop>();
            for (var i = 0; i < ObjectsInfosCount; i++)
            {
                var objectToAdd = new ObjectItemToSellInHumanVendorShop();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}
