using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectTransfertListToInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6039;

        public override ushort MessageID => ProtocolId;

        public List<int> Ids { get; set; }
        public ExchangeObjectTransfertListToInvMessage() { }

        public ExchangeObjectTransfertListToInvMessage( List<int> Ids ){
            this.Ids = Ids;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Ids.Count);
			foreach (var x in Ids)
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
        }
    }
}
