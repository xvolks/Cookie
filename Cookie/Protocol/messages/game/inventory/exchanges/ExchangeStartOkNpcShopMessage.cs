using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkNpcShopMessage : NetworkMessage
    {
        public const uint ProtocolId = 5761;
        public override uint MessageID { get { return ProtocolId; } }

        public double NpcSellerId = 0;
        public short TokenId = 0;
        public List<ObjectItemToSellInNpcShop> ObjectsInfos;

        public ExchangeStartOkNpcShopMessage()
        {
        }

        public ExchangeStartOkNpcShopMessage(
            double npcSellerId,
            short tokenId,
            List<ObjectItemToSellInNpcShop> objectsInfos
        )
        {
            NpcSellerId = npcSellerId;
            TokenId = tokenId;
            ObjectsInfos = objectsInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(NpcSellerId);
            writer.WriteVarShort(TokenId);
            writer.WriteShort((short)ObjectsInfos.Count());
            foreach (var current in ObjectsInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NpcSellerId = reader.ReadDouble();
            TokenId = reader.ReadVarShort();
            var countObjectsInfos = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSellInNpcShop>();
            for (short i = 0; i < countObjectsInfos; i++)
            {
                ObjectItemToSellInNpcShop type = new ObjectItemToSellInNpcShop();
                type.Deserialize(reader);
                ObjectsInfos.Add(type);
            }
        }
    }
}