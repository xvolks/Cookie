using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InteractiveElementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5708;

        public override ushort MessageID => ProtocolId;

        public InteractiveElement InteractiveElement { get; set; }
        public InteractiveElementUpdatedMessage() { }

        public InteractiveElementUpdatedMessage( InteractiveElement InteractiveElement ){
            this.InteractiveElement = InteractiveElement;
        }

        public override void Serialize(IDataWriter writer)
        {
            InteractiveElement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            InteractiveElement = new InteractiveElement();
            InteractiveElement.Deserialize(reader);
        }
    }
}
