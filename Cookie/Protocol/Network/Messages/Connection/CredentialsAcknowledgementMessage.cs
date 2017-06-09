using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Connection
{
    public class CredentialsAcknowledgementMessage : NetworkMessage
    {
        public const uint ProtocolId = 6314;
        public override uint MessageID { get { return ProtocolId; } }

        public CredentialsAcknowledgementMessage() { }

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}
