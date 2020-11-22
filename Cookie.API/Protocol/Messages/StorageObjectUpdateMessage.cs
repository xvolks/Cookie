using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StorageObjectUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5647;

        public override ushort MessageID => ProtocolId;

        public ObjectItem Object { get; set; }
        public StorageObjectUpdateMessage() { }

        public StorageObjectUpdateMessage( ObjectItem Object ){
            this.Object = Object;
        }

        public override void Serialize(IDataWriter writer)
        {
            Object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Object = new ObjectItem();
            Object.Deserialize(reader);
        }
    }
}
