using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LockableStateUpdateAbstractMessage : NetworkMessage
    {
        public const uint ProtocolId = 5671;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Locked = false;

        public LockableStateUpdateAbstractMessage()
        {
        }

        public LockableStateUpdateAbstractMessage(
            bool locked
        )
        {
            Locked = locked;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Locked);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Locked = reader.ReadBoolean();
        }
    }
}