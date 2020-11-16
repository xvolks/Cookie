using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectAveragePricesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6335;

        public override ushort MessageID => ProtocolId;

        public List<short> Ids { get; set; }
        public List<long> AvgPrices { get; set; }
        public ObjectAveragePricesMessage() { }

        public ObjectAveragePricesMessage( List<short> Ids, List<long> AvgPrices ){
            this.Ids = Ids;
            this.AvgPrices = AvgPrices;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Ids.Count);
			foreach (var x in Ids)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)AvgPrices.Count);
			foreach (var x in AvgPrices)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var IdsCount = reader.ReadShort();
            Ids = new List<short>();
            for (var i = 0; i < IdsCount; i++)
            {
                Ids.Add(reader.ReadVarShort());
            }
            var AvgPricesCount = reader.ReadShort();
            AvgPrices = new List<long>();
            for (var i = 0; i < AvgPricesCount; i++)
            {
                AvgPrices.Add(reader.ReadVarLong());
            }
        }
    }
}
