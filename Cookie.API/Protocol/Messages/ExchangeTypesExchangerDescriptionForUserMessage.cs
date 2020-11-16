using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeTypesExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5765;

        public override ushort MessageID => ProtocolId;

        public List<int> TypeDescription { get; set; }
        public ExchangeTypesExchangerDescriptionForUserMessage() { }

        public ExchangeTypesExchangerDescriptionForUserMessage( List<int> TypeDescription ){
            this.TypeDescription = TypeDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)TypeDescription.Count);
			foreach (var x in TypeDescription)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var TypeDescriptionCount = reader.ReadShort();
            TypeDescription = new List<int>();
            for (var i = 0; i < TypeDescriptionCount; i++)
            {
                TypeDescription.Add(reader.ReadVarInt());
            }
        }
    }
}
