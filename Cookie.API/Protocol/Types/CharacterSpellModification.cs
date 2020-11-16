using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterSpellModification : NetworkType
    {
        public const ushort ProtocolId = 215;

        public override ushort TypeID => ProtocolId;

        public sbyte ModificationType { get; set; }
        public ushort SpellId { get; set; }
        public CharacterBaseCharacteristic Value { get; set; }
        public CharacterSpellModification() { }

        public CharacterSpellModification( sbyte ModificationType, ushort SpellId, CharacterBaseCharacteristic Value ){
            this.ModificationType = ModificationType;
            this.SpellId = SpellId;
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ModificationType);
            writer.WriteVarUhShort(SpellId);
            Value.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ModificationType = reader.ReadSByte();
            SpellId = reader.ReadVarUhShort();
            Value = new CharacterBaseCharacteristic();
            Value.Deserialize(reader);
        }
    }
}
