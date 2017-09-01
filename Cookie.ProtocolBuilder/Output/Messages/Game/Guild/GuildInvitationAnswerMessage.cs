namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildInvitationAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5556;
        public override ushort MessageID => ProtocolId;
        public bool Accept { get; set; }

        public GuildInvitationAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public GuildInvitationAnswerMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            Accept = reader.ReadBoolean();
        }

    }
}
