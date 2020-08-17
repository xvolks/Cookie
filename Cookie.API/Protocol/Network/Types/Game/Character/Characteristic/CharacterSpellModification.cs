using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Characteristic
{
    public class CharacterSpellModification : NetworkType
    {
        public const ushort ProtocolId = 215;

        public CharacterSpellModification(byte modificationType, ushort spellId, CharacterBaseCharacteristic value)
        {
            ModificationType = modificationType;
            SpellId = spellId;
            Value = value;
        }

        public CharacterSpellModification()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte ModificationType { get; set; }
        public ushort SpellId { get; set; }
        public CharacterBaseCharacteristic Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ModificationType);
            writer.WriteVarUhShort(SpellId);
            Value.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ModificationType = reader.ReadByte();
            SpellId = reader.ReadVarUhShort();
            Value = new CharacterBaseCharacteristic();
            Value.Deserialize(reader);
        }
    }
}