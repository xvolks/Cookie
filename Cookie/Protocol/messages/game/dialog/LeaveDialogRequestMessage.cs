using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LeaveDialogRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5501;
        public override uint MessageID { get { return ProtocolId; } }

        public LeaveDialogRequestMessage()
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