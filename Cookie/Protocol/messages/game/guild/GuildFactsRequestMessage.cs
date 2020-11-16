using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFactsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6404;
        public override uint MessageID { get { return ProtocolId; } }

        public int GuildId = 0;

        public GuildFactsRequestMessage()
        {
        }

        public GuildFactsRequestMessage(
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