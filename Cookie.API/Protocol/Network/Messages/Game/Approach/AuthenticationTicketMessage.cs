namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    using Utils.IO;

    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const ushort ProtocolId = 110;
        public override ushort MessageID => ProtocolId;
        public string Lang { get; set; }
        public string Ticket { get; set; }

        public AuthenticationTicketMessage(string lang, string ticket)
        {
            Lang = lang;
            Ticket = ticket;
        }

        public AuthenticationTicketMessage() { }

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
