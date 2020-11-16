using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkNpcShopMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5761;

        public override ushort MessageID => ProtocolId;

        public double NpcSellerId { get; set; }
        public ushort TokenId { get; set; }
        public List<ObjectItemToSellInNpcShop> ObjectsInfos { get; set; }
        public ExchangeStartOkNpcShopMessage() { }

        public ExchangeStartOkNpcShopMessage( double NpcSellerId, ushort TokenId, List<ObjectItemToSellInNpcShop> ObjectsInfos ){
            this.NpcSellerId = NpcSellerId;
            this.TokenId = TokenId;
            this.ObjectsInfos = ObjectsInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(NpcSellerId);
            writer.WriteVarUhShort(TokenId);
			writer.WriteShort((short)ObjectsInfos.Count);
			foreach (var x in ObjectsInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcSellerId = reader.ReadDouble();
            TokenId = reader.ReadVarUhShort();
            var ObjectsInfosCount = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSellInNpcShop>();
            for (var i = 0; i < ObjectsInfosCount; i++)
            {
                var objectToAdd = new ObjectItemToSellInNpcShop();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}
