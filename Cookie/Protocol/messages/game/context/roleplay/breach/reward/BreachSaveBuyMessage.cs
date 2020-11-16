using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachSaveBuyMessage : NetworkMessage
    {
        public const uint ProtocolId = 6787;
        public override uint MessageID { get { return ProtocolId; } }

        public BreachSaveBuyMessage()
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