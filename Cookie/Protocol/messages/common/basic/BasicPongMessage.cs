using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicPongMessage : NetworkMessage
    {
        public const uint ProtocolId = 183;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Quiet = false;

        public BasicPongMessage()
        {
        }

        public BasicPongMessage(
            bool quiet
        )
        {
            Quiet = quiet;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Quiet);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Quiet = reader.ReadBoolean();
        }
    }
}