using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectAveragePricesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6335;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Ids;
        public List<long> AvgPrices;

        public ObjectAveragePricesMessage()
        {
        }

        public ObjectAveragePricesMessage(
            List<short> ids,
            List<long> avgPrices
        )
        {
            Ids = ids;
            AvgPrices = avgPrices;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Ids.Count());
            foreach (var current in Ids)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)AvgPrices.Count());
            foreach (var current in AvgPrices)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countIds = reader.ReadShort();
            Ids = new List<short>();
            for (short i = 0; i < countIds; i++)
            {
                Ids.Add(reader.ReadVarShort());
            }
            var countAvgPrices = reader.ReadShort();
            AvgPrices = new List<long>();
            for (short i = 0; i < countAvgPrices; i++)
            {
                AvgPrices.Add(reader.ReadVarLong());
            }
        }
    }
}