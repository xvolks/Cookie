using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectModifiedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3029;

        public override ushort MessageID => ProtocolId;

        public ObjectItem Object { get; set; }
        public ObjectModifiedMessage() { }

        public ObjectModifiedMessage( ObjectItem Object ){
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
