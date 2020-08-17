using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceInvitationAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6401;

        public AllianceInvitationAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public AllianceInvitationAnswerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Accept { get; set; }

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