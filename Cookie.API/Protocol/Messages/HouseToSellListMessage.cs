using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseToSellListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6140;

        public override ushort MessageID => ProtocolId;

        public ushort PageIndex { get; set; }
        public ushort TotalPage { get; set; }
        public List<HouseInformationsForSell> HouseList { get; set; }
        public HouseToSellListMessage() { }

        public HouseToSellListMessage( ushort PageIndex, ushort TotalPage, List<HouseInformationsForSell> HouseList ){
            this.PageIndex = PageIndex;
            this.TotalPage = TotalPage;
            this.HouseList = HouseList;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(PageIndex);
            writer.WriteVarUhShort(TotalPage);
			writer.WriteShort((short)HouseList.Count);
			foreach (var x in HouseList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUhShort();
            TotalPage = reader.ReadVarUhShort();
            var HouseListCount = reader.ReadShort();
            HouseList = new List<HouseInformationsForSell>();
            for (var i = 0; i < HouseListCount; i++)
            {
                var objectToAdd = new HouseInformationsForSell();
                objectToAdd.Deserialize(reader);
                HouseList.Add(objectToAdd);
            }
        }
    }
}
