using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceChangeGuildRightsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6426;
        public override uint MessageID { get { return ProtocolId; } }

        public int GuildId = 0;
        public byte Rights = 0;

        public AllianceChangeGuildRightsMessage()
        {
        }

        public AllianceChangeGuildRightsMessage(
            int guildId,
            byte rights
        )
        {
            GuildId = guildId;
            Rights = rights;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(GuildId);
            writer.WriteByte(Rights);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildId = reader.ReadVarInt();
            Rights = reader.ReadByte();
        }
    }
}