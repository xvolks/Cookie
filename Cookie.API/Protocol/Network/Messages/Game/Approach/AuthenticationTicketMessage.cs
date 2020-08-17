using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const ushort ProtocolId = 110;

        public AuthenticationTicketMessage(string lang, string ticket)
        {
            Lang = lang;
            Ticket = ticket;
        }

        public AuthenticationTicketMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Lang { get; set; }
        public string Ticket { get; set; }

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