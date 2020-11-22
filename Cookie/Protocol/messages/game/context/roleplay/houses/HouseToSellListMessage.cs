using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseToSellListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6140;
        public override uint MessageID { get { return ProtocolId; } }

        public short PageIndex = 0;
        public short TotalPage = 0;
        public List<HouseInformationsForSell> HouseList;

        public HouseToSellListMessage()
        {
        }

        public HouseToSellListMessage(
            short pageIndex,
            short totalPage,
            List<HouseInformationsForSell> houseList
        )
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            HouseList = houseList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(PageIndex);
            writer.WriteVarShort(TotalPage);
            writer.WriteShort((short)HouseList.Count());
            foreach (var current in HouseList)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PageIndex = reader.ReadVarShort();
            TotalPage = reader.ReadVarShort();
            var countHouseList = reader.ReadShort();
            HouseList = new List<HouseInformationsForSell>();
            for (short i = 0; i < countHouseList; i++)
            {
                HouseInformationsForSell type = new HouseInformationsForSell();
                type.Deserialize(reader);
                HouseList.Add(type);
            }
        }
    }
}