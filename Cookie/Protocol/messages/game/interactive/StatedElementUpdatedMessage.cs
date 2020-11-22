using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StatedElementUpdatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5709;
        public override uint MessageID { get { return ProtocolId; } }

        public StatedElement StatedElement_;

        public StatedElementUpdatedMessage()
        {
        }

        public StatedElementUpdatedMessage(
            StatedElement statedElement_
        )
        {
            StatedElement_ = statedElement_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            StatedElement_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            StatedElement_ = new StatedElement();
            StatedElement_.Deserialize(reader);
        }
    }
}