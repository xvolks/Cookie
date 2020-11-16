using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StorageObjectsRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6035;

        public override ushort MessageID => ProtocolId;

        public List<int> ObjectUIDList { get; set; }
        public StorageObjectsRemoveMessage() { }

        public StorageObjectsRemoveMessage( List<int> ObjectUIDList ){
            this.ObjectUIDList = ObjectUIDList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectUIDList.Count);
			foreach (var x in ObjectUIDList)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectUIDListCount = reader.ReadShort();
            ObjectUIDList = new List<int>();
            for (var i = 0; i < ObjectUIDListCount; i++)
            {
                ObjectUIDList.Add(reader.ReadVarInt());
            }
        }
    }
}
