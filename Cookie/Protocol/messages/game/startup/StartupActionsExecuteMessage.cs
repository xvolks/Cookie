using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StartupActionsExecuteMessage : NetworkMessage
    {
        public const uint ProtocolId = 1302;
        public override uint MessageID { get { return ProtocolId; } }

        public StartupActionsExecuteMessage()
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