using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeMountsStableRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6556;

        public override ushort MessageID => ProtocolId;

        public List<int> MountsId { get; set; }
        public ExchangeMountsStableRemoveMessage() { }

        public ExchangeMountsStableRemoveMessage( List<int> MountsId ){
            this.MountsId = MountsId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)MountsId.Count);
			foreach (var x in MountsId)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MountsIdCount = reader.ReadShort();
            MountsId = new List<int>();
            for (var i = 0; i < MountsIdCount; i++)
            {
                MountsId.Add(reader.ReadVarInt());
            }
        }
    }
}
