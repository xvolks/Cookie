using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildLevelUpMessage : NetworkMessage
    {
        public const uint ProtocolId = 6062;
        public override uint MessageID { get { return ProtocolId; } }

        public byte NewLevel = 0;

        public GuildLevelUpMessage()
        {
        }

        public GuildLevelUpMessage(
            byte newLevel
        )
        {
            NewLevel = newLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(NewLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NewLevel = reader.ReadByte();
        }
    }
}