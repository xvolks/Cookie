using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const uint ProtocolId = 110;
        public override uint MessageID { get { return ProtocolId; } }

        public string Lang;
        public string Ticket;

        public AuthenticationTicketMessage()
        {
        }

        public AuthenticationTicketMessage(
            string lang,
            string ticket
        )
        {
            Lang = lang;
            Ticket = ticket;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Lang);
            writer.WriteUTF(Ticket);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Lang = reader.ReadUTF();
            Ticket = reader.ReadUTF();
        }
    }
}