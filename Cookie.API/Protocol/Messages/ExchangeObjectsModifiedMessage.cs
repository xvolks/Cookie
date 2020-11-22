using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectsModifiedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6533;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItem> Object { get; set; }
        public ExchangeObjectsModifiedMessage() { }

        public ExchangeObjectsModifiedMessage( List<ObjectItem> Object ){
            this.Object = Object;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Object.Count);
			foreach (var x in Object)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ObjectCount = reader.ReadShort();
            Object = new List<ObjectItem>();
            for (var i = 0; i < ObjectCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Object.Add(objectToAdd);
            }
        }
    }
}
