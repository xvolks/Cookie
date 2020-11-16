using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildModificationNameValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6327;
        public override uint MessageID { get { return ProtocolId; } }

        public string GuildName;

        public GuildModificationNameValidMessage()
        {
        }

        public GuildModificationNameValidMessage(
            string guildName
        )
        {
            GuildName = guildName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(GuildName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildName = reader.ReadUTF();
        }
    }
}