using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ContactLookRequestByNameMessage : ContactLookRequestMessage
    {
        public new const ushort ProtocolId = 5933;

        public override ushort MessageID => ProtocolId;

        public string PlayerName { get; set; }
        public ContactLookRequestByNameMessage() { }

        public ContactLookRequestByNameMessage( string PlayerName ){
            this.PlayerName = PlayerName;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerName = reader.ReadUTF();
        }
    }
}
