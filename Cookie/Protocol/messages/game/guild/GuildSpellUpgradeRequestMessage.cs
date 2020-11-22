using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildSpellUpgradeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5699;
        public override uint MessageID { get { return ProtocolId; } }

        public int SpellId = 0;

        public GuildSpellUpgradeRequestMessage()
        {
        }

        public GuildSpellUpgradeRequestMessage(
            int spellId
        )
        {
            SpellId = spellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(SpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadInt();
        }
    }
}