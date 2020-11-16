using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
    {
        public new const ushort ProtocolId = 852;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItem> Objects { get; set; }
        public ChatClientPrivateWithObjectMessage() { }

        public ChatClientPrivateWithObjectMessage( List<ObjectItem> Objects ){
            this.Objects = Objects;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Objects.Count);
			foreach (var x in Objects)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ObjectsCount = reader.ReadShort();
            Objects = new List<ObjectItem>();
            for (var i = 0; i < ObjectsCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Objects.Add(objectToAdd);
            }
        }
    }
}
