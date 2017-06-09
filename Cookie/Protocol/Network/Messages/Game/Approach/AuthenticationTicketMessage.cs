using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const uint ProtocolId = 110;
        public override uint MessageID { get { return ProtocolId; } }

        public string Lang { get; set; }
        public string Ticket { get; set; }

        public AuthenticationTicketMessage() { }

        public AuthenticationTicketMessage(string lang, string ticket)
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
