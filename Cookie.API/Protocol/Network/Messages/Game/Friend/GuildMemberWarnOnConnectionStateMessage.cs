using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class GuildMemberWarnOnConnectionStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6160;

        public GuildMemberWarnOnConnectionStateMessage(bool enable)
        {
            Enable = enable;
        }

        public GuildMemberWarnOnConnectionStateMessage()
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