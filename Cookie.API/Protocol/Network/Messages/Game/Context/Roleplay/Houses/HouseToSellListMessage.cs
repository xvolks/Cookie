using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.House;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseToSellListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6140;

        public HouseToSellListMessage(ushort pageIndex, ushort totalPage, List<HouseInformationsForSell> houseList)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            HouseList = houseList;
        }

        public HouseToSellListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort PageIndex { get; set; }
        public ushort TotalPage { get; set; }
        public List<HouseInformationsForSell> HouseList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(PageIndex);
            writer.WriteVarUhShort(TotalPage);
            writer.WriteShort((short) HouseList.Count);
            for (var houseListIndex = 0; houseListIndex < HouseList.Count; houseListIndex++)
            {
                var objectToSend = HouseList[houseListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUhShort();
            TotalPage = reader.ReadVarUhShort();
            var houseListCount = reader.ReadUShort();
            HouseList = new List<HouseInformationsForSell>();
            for (var houseListIndex = 0; houseListIndex < houseListCount; houseListIndex++)
            {
                var objectToAdd = new HouseInformationsForSell();
                objectToAdd.Deserialize(reader);
                HouseList.Add(objectToAdd);
            }
        }
    }
}