using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachExitResponseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6814;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Exited = false;

        public BreachExitResponseMessage()
        {
        }

        public BreachExitResponseMessage(
            bool exited
        )
        {
            Exited = exited;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Exited);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Exited = reader.ReadBoolean();
        }
    }
}