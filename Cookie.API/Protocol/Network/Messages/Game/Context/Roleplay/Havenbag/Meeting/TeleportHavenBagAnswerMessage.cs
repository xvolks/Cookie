using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    public class TeleportHavenBagAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6646;

        public TeleportHavenBagAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public TeleportHavenBagAnswerMessage()
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