using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EditHavenBagCancelRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6619;
        public override uint MessageID { get { return ProtocolId; } }

        public EditHavenBagCancelRequestMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}