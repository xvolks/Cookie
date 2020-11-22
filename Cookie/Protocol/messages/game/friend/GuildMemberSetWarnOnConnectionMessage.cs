using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildMemberSetWarnOnConnectionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6159;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Enable = false;

        public GuildMemberSetWarnOnConnectionMessage()
        {
        }

        public GuildMemberSetWarnOnConnectionMessage(
            bool enable
        )
        {
            Enable = enable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}