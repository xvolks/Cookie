using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceGuildLeavingMessage : NetworkMessage
    {
        public const uint ProtocolId = 6399;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Kicked = false;
        public int GuildId = 0;

        public AllianceGuildLeavingMessage()
        {
        }

        public AllianceGuildLeavingMessage(
            bool kicked,
            int guildId
        )
        {
            Kicked = kicked;
            GuildId = guildId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Kicked);
            writer.WriteVarInt(GuildId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Kicked = reader.ReadBoolean();
            GuildId = reader.ReadVarInt();
        }
    }
}