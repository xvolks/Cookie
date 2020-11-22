using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachKickRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6804;
        public override uint MessageID { get { return ProtocolId; } }

        public long Target = 0;

        public BreachKickRequestMessage()
        {
        }

        public BreachKickRequestMessage(
            long target
        )
        {
            Target = target;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Target);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Target = reader.ReadVarLong();
        }
    }
}