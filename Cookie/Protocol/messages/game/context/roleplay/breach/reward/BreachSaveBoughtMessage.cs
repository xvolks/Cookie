using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachSaveBoughtMessage : NetworkMessage
    {
        public const uint ProtocolId = 6788;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Bought = false;

        public BreachSaveBoughtMessage()
        {
        }

        public BreachSaveBoughtMessage(
            bool bought
        )
        {
            Bought = bought;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Bought = reader.ReadBoolean();
        }
    }
}