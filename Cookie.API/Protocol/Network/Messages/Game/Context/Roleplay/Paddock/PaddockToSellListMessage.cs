using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Paddock;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockToSellListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6138;

        public PaddockToSellListMessage(ushort pageIndex, ushort totalPage,
            List<PaddockInformationsForSell> paddockList)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            PaddockList = paddockList;
        }

        public PaddockToSellListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort PageIndex { get; set; }
        public ushort TotalPage { get; set; }
        public List<PaddockInformationsForSell> PaddockList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(PageIndex);
            writer.WriteVarUhShort(TotalPage);
            writer.WriteShort((short) PaddockList.Count);
            for (var paddockListIndex = 0; paddockListIndex < PaddockList.Count; paddockListIndex++)
            {
                var objectToSend = PaddockList[paddockListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUhShort();
            TotalPage = reader.ReadVarUhShort();
            var paddockListCount = reader.ReadUShort();
            PaddockList = new List<PaddockInformationsForSell>();
            for (var paddockListIndex = 0; paddockListIndex < paddockListCount; paddockListIndex++)
            {
                var objectToAdd = new PaddockInformationsForSell();
                objectToAdd.Deserialize(reader);
                PaddockList.Add(objectToAdd);
            }
        }
    }
}