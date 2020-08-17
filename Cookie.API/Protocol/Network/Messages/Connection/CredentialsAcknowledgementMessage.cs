namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Utils.IO;

    public class CredentialsAcknowledgementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6314;
        public override ushort MessageID => ProtocolId;

        public CredentialsAcknowledgementMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
