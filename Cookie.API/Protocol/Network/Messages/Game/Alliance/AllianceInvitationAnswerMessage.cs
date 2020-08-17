namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceInvitationAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6401;
        public override ushort MessageID => ProtocolId;
        public bool Accept { get; set; }

        public AllianceInvitationAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public AllianceInvitationAnswerMessage() { }

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
