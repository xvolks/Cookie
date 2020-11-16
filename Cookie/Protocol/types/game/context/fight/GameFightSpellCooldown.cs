using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightSpellCooldown : NetworkType
    {
        public const short ProtocolId = 205;
        public override short TypeId { get { return ProtocolId; } }

        public int SpellId = 0;
        public byte Cooldown = 0;

        public GameFightSpellCooldown()
        {
        }

        public GameFightSpellCooldown(
            int spellId,
            byte cooldown
        )
        {
            SpellId = spellId;
            Cooldown = cooldown;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(SpellId);
            writer.WriteByte(Cooldown);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadInt();
            Cooldown = reader.ReadByte();
        }
    }
}