using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterSpellModification : NetworkType
    {
        public const short ProtocolId = 215;
        public override short TypeId { get { return ProtocolId; } }

        public byte ModificationType = 0;
        public short SpellId = 0;
        public CharacterBaseCharacteristic Value;

        public CharacterSpellModification()
        {
        }

        public CharacterSpellModification(
            byte modificationType,
            short spellId,
            CharacterBaseCharacteristic value
        )
        {
            ModificationType = modificationType;
            SpellId = spellId;
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ModificationType);
            writer.WriteVarShort(SpellId);
            Value.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ModificationType = reader.ReadByte();
            SpellId = reader.ReadVarShort();
            Value = new CharacterBaseCharacteristic();
            Value.Deserialize(reader);
        }
    }
}