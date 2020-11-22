using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolPartyRegisterRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6582;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Register = false;

        public IdolPartyRegisterRequestMessage()
        {
        }

        public IdolPartyRegisterRequestMessage(
            bool register
        )
        {
            Register = register;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Register);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Register = reader.ReadBoolean();
        }
    }
}