using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightSpellCooldown : NetworkType
    {
        public const ushort ProtocolId = 205;

        public GameFightSpellCooldown(int spellId, byte cooldown)
        {
            SpellId = spellId;
            Cooldown = cooldown;
        }

        public GameFightSpellCooldown()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int SpellId { get; set; }
        public byte Cooldown { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
            writer.WriteByte(Cooldown);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
            Cooldown = reader.ReadByte();
        }
    }
}