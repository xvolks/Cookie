using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectsDeletedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6034;

        public override ushort MessageID => ProtocolId;

        public List<int> ObjectUID { get; set; }
        public ObjectsDeletedMessage() { }

        public ObjectsDeletedMessage( List<int> ObjectUID ){
            this.ObjectUID = ObjectUID;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectUID.Count);
			foreach (var x in ObjectUID)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectUIDCount = reader.ReadShort();
            ObjectUID = new List<int>();
            for (var i = 0; i < ObjectUIDCount; i++)
            {
                ObjectUID.Add(reader.ReadVarInt());
            }
        }
    }
}
