using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismSettingsErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6442;
        public override uint MessageID { get { return ProtocolId; } }

        public PrismSettingsErrorMessage()
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