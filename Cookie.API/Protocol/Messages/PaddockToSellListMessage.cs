using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockToSellListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6138;

        public override ushort MessageID => ProtocolId;

        public ushort PageIndex { get; set; }
        public ushort TotalPage { get; set; }
        public List<PaddockInformationsForSell> PaddockList { get; set; }
        public PaddockToSellListMessage() { }

        public PaddockToSellListMessage( ushort PageIndex, ushort TotalPage, List<PaddockInformationsForSell> PaddockList ){
            this.PageIndex = PageIndex;
            this.TotalPage = TotalPage;
            this.PaddockList = PaddockList;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(PageIndex);
            writer.WriteVarUhShort(TotalPage);
			writer.WriteShort((short)PaddockList.Count);
			foreach (var x in PaddockList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUhShort();
            TotalPage = reader.ReadVarUhShort();
            var PaddockListCount = reader.ReadShort();
            PaddockList = new List<PaddockInformationsForSell>();
            for (var i = 0; i < PaddockListCount; i++)
            {
                var objectToAdd = new PaddockInformationsForSell();
                objectToAdd.Deserialize(reader);
                PaddockList.Add(objectToAdd);
            }
        }
    }
}
