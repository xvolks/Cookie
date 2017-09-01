using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInvitationAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5556;

        public GuildInvitationAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public GuildInvitationAnswerMessage()
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