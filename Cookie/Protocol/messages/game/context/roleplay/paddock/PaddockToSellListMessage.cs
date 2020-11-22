using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockToSellListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6138;
        public override uint MessageID { get { return ProtocolId; } }

        public short PageIndex = 0;
        public short TotalPage = 0;
        public List<PaddockInformationsForSell> PaddockList;

        public PaddockToSellListMessage()
        {
        }

        public PaddockToSellListMessage(
            short pageIndex,
            short totalPage,
            List<PaddockInformationsForSell> paddockList
        )
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            PaddockList = paddockList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(PageIndex);
            writer.WriteVarShort(TotalPage);
            writer.WriteShort((short)PaddockList.Count());
            foreach (var current in PaddockList)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PageIndex = reader.ReadVarShort();
            TotalPage = reader.ReadVarShort();
            var countPaddockList = reader.ReadShort();
            PaddockList = new List<PaddockInformationsForSell>();
            for (short i = 0; i < countPaddockList; i++)
            {
                PaddockInformationsForSell type = new PaddockInformationsForSell();
                type.Deserialize(reader);
                PaddockList.Add(type);
            }
        }
    }
}