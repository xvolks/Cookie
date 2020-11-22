using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkJobIndexMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5819;

        public override ushort MessageID => ProtocolId;

        public List<int> Jobs { get; set; }
        public ExchangeStartOkJobIndexMessage() { }

        public ExchangeStartOkJobIndexMessage( List<int> Jobs ){
            this.Jobs = Jobs;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Jobs.Count);
			foreach (var x in Jobs)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var JobsCount = reader.ReadShort();
            Jobs = new List<int>();
            for (var i = 0; i < JobsCount; i++)
            {
                Jobs.Add(reader.ReadVarInt());
            }
        }
    }
}
