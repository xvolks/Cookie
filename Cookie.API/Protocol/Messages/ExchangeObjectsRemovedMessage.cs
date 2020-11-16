using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6532;

        public override ushort MessageID => ProtocolId;

        public List<int> ObjectUID { get; set; }
        public ExchangeObjectsRemovedMessage() { }

        public ExchangeObjectsRemovedMessage( List<int> ObjectUID ){
            this.ObjectUID = ObjectUID;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)ObjectUID.Count);
			foreach (var x in ObjectUID)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ObjectUIDCount = reader.ReadShort();
            ObjectUID = new List<int>();
            for (var i = 0; i < ObjectUIDCount; i++)
            {
                ObjectUID.Add(reader.ReadVarInt());
            }
        }
    }
}
