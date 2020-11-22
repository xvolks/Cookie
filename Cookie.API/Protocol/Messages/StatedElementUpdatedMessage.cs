using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StatedElementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5709;

        public override ushort MessageID => ProtocolId;

        public StatedElement StatedElement { get; set; }
        public StatedElementUpdatedMessage() { }

        public StatedElementUpdatedMessage( StatedElement StatedElement ){
            this.StatedElement = StatedElement;
        }

        public override void Serialize(IDataWriter writer)
        {
            StatedElement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatedElement = new StatedElement();
            StatedElement.Deserialize(reader);
        }
    }
}
