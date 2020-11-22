using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        public new const ushort ProtocolId = 6209;

        public override ushort MessageID => ProtocolId;

        public string LoginToken { get; set; }
        public IdentificationSuccessWithLoginTokenMessage() { }

        public IdentificationSuccessWithLoginTokenMessage( string LoginToken ){
            this.LoginToken = LoginToken;
        }

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
