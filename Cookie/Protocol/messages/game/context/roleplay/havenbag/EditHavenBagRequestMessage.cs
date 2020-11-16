using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EditHavenBagRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6626;
        public override uint MessageID { get { return ProtocolId; } }

        public EditHavenBagRequestMessage()
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