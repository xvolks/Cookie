using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EnterHavenBagRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6636;
        public override uint MessageID { get { return ProtocolId; } }

        public long HavenBagOwner = 0;

        public EnterHavenBagRequestMessage()
        {
        }

        public EnterHavenBagRequestMessage(
            long havenBagOwner
        )
        {
            HavenBagOwner = havenBagOwner;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(HavenBagOwner);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HavenBagOwner = reader.ReadVarLong();
        }
    }
}