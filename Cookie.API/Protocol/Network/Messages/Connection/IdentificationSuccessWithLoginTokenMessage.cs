using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        public new const ushort ProtocolId = 6209;

        public IdentificationSuccessWithLoginTokenMessage(string loginToken)
        {
            LoginToken = loginToken;
        }

        public IdentificationSuccessWithLoginTokenMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string LoginToken { get; set; }

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