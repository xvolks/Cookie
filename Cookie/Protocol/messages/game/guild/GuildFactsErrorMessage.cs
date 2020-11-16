using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFactsErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6424;
        public override uint MessageID { get { return ProtocolId; } }

        public int GuildId = 0;

        public GuildFactsErrorMessage()
        {
        }

        public GuildFactsErrorMessage(
            int guildId
        )
        {
            GuildId = guildId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(GuildId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildId = reader.ReadVarInt();
        }
    }
}