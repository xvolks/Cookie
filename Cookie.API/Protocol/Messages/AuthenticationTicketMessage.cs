using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const ushort ProtocolId = 110;

        public override ushort MessageID => ProtocolId;

        public string Lang { get; set; }
        public string Ticket { get; set; }
        public AuthenticationTicketMessage() { }

        public AuthenticationTicketMessage( string Lang, string Ticket ){
            this.Lang = Lang;
            this.Ticket = Ticket;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Lang);
            writer.WriteUTF(Ticket);
        }

        public override void Deserialize(IDataReader reader)
        {
            Lang = reader.ReadUTF();
            Ticket = reader.ReadUTF();
        }
    }
}
