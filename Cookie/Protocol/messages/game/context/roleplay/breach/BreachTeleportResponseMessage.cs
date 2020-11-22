using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachTeleportResponseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6816;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Teleported = false;

        public BreachTeleportResponseMessage()
        {
        }

        public BreachTeleportResponseMessage(
            bool teleported
        )
        {
            Teleported = teleported;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Teleported);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Teleported = reader.ReadBoolean();
        }
    }
}