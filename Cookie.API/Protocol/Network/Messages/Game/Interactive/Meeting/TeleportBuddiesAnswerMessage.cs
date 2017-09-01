using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    public class TeleportBuddiesAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6294;

        public TeleportBuddiesAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public TeleportBuddiesAnswerMessage()
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