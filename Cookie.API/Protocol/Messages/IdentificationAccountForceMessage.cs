using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdentificationAccountForceMessage : IdentificationMessage
    {
        public new const ushort ProtocolId = 6119;

        public override ushort MessageID => ProtocolId;

        public string ForcedAccountLogin { get; set; }
        public IdentificationAccountForceMessage() { }

        public IdentificationAccountForceMessage( string ForcedAccountLogin ){
            this.ForcedAccountLogin = ForcedAccountLogin;
        }

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
