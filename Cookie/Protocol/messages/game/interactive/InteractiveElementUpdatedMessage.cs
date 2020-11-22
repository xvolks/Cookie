using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InteractiveElementUpdatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5708;
        public override uint MessageID { get { return ProtocolId; } }

        public InteractiveElement InteractiveElement_;

        public InteractiveElementUpdatedMessage()
        {
        }

        public InteractiveElementUpdatedMessage(
            InteractiveElement interactiveElement_
        )
        {
            InteractiveElement_ = interactiveElement_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            InteractiveElement_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            InteractiveElement_ = new InteractiveElement();
            InteractiveElement_.Deserialize(reader);
        }
    }
}