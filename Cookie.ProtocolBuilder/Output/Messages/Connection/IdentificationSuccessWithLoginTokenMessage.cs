namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Utils.IO;

    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        public new const ushort ProtocolId = 6209;
        public override ushort MessageID => ProtocolId;
        public string LoginToken { get; set; }

        public IdentificationSuccessWithLoginTokenMessage(string loginToken)
        {
            LoginToken = loginToken;
        }

        public IdentificationSuccessWithLoginTokenMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LoginToken);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LoginToken = reader.ReadUTF();
        }

    }
}
