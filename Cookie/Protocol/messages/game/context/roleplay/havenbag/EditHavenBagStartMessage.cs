using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EditHavenBagStartMessage : NetworkMessage
    {
        public const uint ProtocolId = 6632;
        public override uint MessageID { get { return ProtocolId; } }

        public EditHavenBagStartMessage()
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