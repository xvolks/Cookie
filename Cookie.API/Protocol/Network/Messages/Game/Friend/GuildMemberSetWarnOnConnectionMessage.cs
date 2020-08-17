using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class GuildMemberSetWarnOnConnectionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6159;

        public GuildMemberSetWarnOnConnectionMessage(bool enable)
        {
            Enable = enable;
        }

        public GuildMemberSetWarnOnConnectionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}