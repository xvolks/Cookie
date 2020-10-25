using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachEnterMessage : NetworkMessage
    {
        public const uint ProtocolId = 6810;
        public override uint MessageID { get { return ProtocolId; } }

        public long Owner = 0;

        public BreachEnterMessage()
        {
        }

        public BreachEnterMessage(
            long owner
        )
        {
            Owner = owner;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Owner);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Owner = reader.ReadVarLong();
        }
    }
}