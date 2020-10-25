using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedTaxCollectorShopMessage : NetworkMessage
    {
        public const uint ProtocolId = 6664;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItem> Objects;
        public long Kamas = 0;

        public ExchangeStartedTaxCollectorShopMessage()
        {
        }

        public ExchangeStartedTaxCollectorShopMessage(
            List<ObjectItem> objects,
            long kamas
        )
        {
            Objects = objects;
            Kamas = kamas;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Objects.Count());
            foreach (var current in Objects)
            {
                current.Serialize(writer);
            }
            writer.WriteVarLong(Kamas);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjects = reader.ReadShort();
            Objects = new List<ObjectItem>();
            for (short i = 0; i < countObjects; i++)
            {
                ObjectItem type = new ObjectItem();
                type.Deserialize(reader);
                Objects.Add(type);
            }
            Kamas = reader.ReadVarLong();
        }
    }
}