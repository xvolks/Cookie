using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicWhoAmIRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5664;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Verbose = false;

        public BasicWhoAmIRequestMessage()
        {
        }

        public BasicWhoAmIRequestMessage(
            bool verbose
        )
        {
            Verbose = verbose;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Verbose = reader.ReadBoolean();
        }
    }
}