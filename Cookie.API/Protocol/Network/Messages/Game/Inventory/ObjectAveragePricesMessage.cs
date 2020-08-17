namespace Cookie.API.Protocol.Network.Messages.Game.Inventory
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ObjectAveragePricesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6335;
        public override ushort MessageID => ProtocolId;
        public List<ushort> Ids { get; set; }
        public List<ulong> AvgPrices { get; set; }

        public ObjectAveragePricesMessage(List<ushort> ids, List<ulong> avgPrices)
        {
            Ids = ids;
            AvgPrices = avgPrices;
        }

        public ObjectAveragePricesMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Ids.Count);
            for (var idsIndex = 0; idsIndex < Ids.Count; idsIndex++)
            {
                writer.WriteVarUhShort(Ids[idsIndex]);
            }
            writer.WriteShort((short)AvgPrices.Count);
            for (var avgPricesIndex = 0; avgPricesIndex < AvgPrices.Count; avgPricesIndex++)
            {
                writer.WriteVarUhLong(AvgPrices[avgPricesIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new List<ushort>();
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
            {
                Ids.Add(reader.ReadVarUhShort());
            }
            var avgPricesCount = reader.ReadUShort();
            AvgPrices = new List<ulong>();
            for (var avgPricesIndex = 0; avgPricesIndex < avgPricesCount; avgPricesIndex++)
            {
                AvgPrices.Add(reader.ReadVarUhLong());
            }
        }

    }
}
