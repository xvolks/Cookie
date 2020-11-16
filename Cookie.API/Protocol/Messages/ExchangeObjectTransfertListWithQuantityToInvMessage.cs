using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectTransfertListWithQuantityToInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6470;

        public override ushort MessageID => ProtocolId;

        public List<int> Ids { get; set; }
        public List<int> Qtys { get; set; }
        public ExchangeObjectTransfertListWithQuantityToInvMessage() { }

        public ExchangeObjectTransfertListWithQuantityToInvMessage( List<int> Ids, List<int> Qtys ){
            this.Ids = Ids;
            this.Qtys = Qtys;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Ids.Count);
			foreach (var x in Ids)
			{
				writer.WriteVarInt(x);
			}
			writer.WriteShort((short)Qtys.Count);
			foreach (var x in Qtys)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var IdsCount = reader.ReadShort();
            Ids = new List<int>();
            for (var i = 0; i < IdsCount; i++)
            {
                Ids.Add(reader.ReadVarInt());
            }
            var QtysCount = reader.ReadShort();
            Qtys = new List<int>();
            for (var i = 0; i < QtysCount; i++)
            {
                Qtys.Add(reader.ReadVarInt());
            }
        }
    }
}
