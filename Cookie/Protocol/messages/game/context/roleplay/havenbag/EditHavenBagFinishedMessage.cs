using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EditHavenBagFinishedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6628;
        public override uint MessageID { get { return ProtocolId; } }

        public EditHavenBagFinishedMessage()
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