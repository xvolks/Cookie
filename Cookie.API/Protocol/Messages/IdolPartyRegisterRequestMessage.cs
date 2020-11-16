using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolPartyRegisterRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6582;

        public override ushort MessageID => ProtocolId;

        public bool Register { get; set; }
        public IdolPartyRegisterRequestMessage() { }

        public IdolPartyRegisterRequestMessage( bool Register ){
            this.Register = Register;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Register);
        }

        public override void Deserialize(IDataReader reader)
        {
            Register = reader.ReadBoolean();
        }
    }
}
