using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachSavedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6798;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Saved = false;

        public BreachSavedMessage()
        {
        }

        public BreachSavedMessage(
            bool saved
        )
        {
            Saved = saved;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Saved);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Saved = reader.ReadBoolean();
        }
    }
}