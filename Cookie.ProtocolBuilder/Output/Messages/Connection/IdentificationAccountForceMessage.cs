namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Types.Version;
    using System.Collections.Generic;
    using Utils.IO;

    public class IdentificationAccountForceMessage : IdentificationMessage
    {
        public new const ushort ProtocolId = 6119;
        public override ushort MessageID => ProtocolId;
        public string ForcedAccountLogin { get; set; }

        public IdentificationAccountForceMessage(string forcedAccountLogin)
        {
            ForcedAccountLogin = forcedAccountLogin;
        }

        public IdentificationAccountForceMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(ForcedAccountLogin);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ForcedAccountLogin = reader.ReadUTF();
        }

    }
}
