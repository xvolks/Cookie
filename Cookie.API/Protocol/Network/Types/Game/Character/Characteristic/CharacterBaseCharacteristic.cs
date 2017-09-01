using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Characteristic
{
    public class CharacterBaseCharacteristic : NetworkType
    {
        public const ushort ProtocolId = 4;

        public CharacterBaseCharacteristic(short @base, short additionnal, short objectsAndMountBonus,
            short alignGiftBonus, short contextModif)
        {
            Base = @base;
            Additionnal = additionnal;
            ObjectsAndMountBonus = objectsAndMountBonus;
            AlignGiftBonus = alignGiftBonus;
            ContextModif = contextModif;
        }

        public CharacterBaseCharacteristic()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short Base { get; set; }
        public short Additionnal { get; set; }
        public short ObjectsAndMountBonus { get; set; }
        public short AlignGiftBonus { get; set; }
        public short ContextModif { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(Base);
            writer.WriteVarShort(Additionnal);
            writer.WriteVarShort(ObjectsAndMountBonus);
            writer.WriteVarShort(AlignGiftBonus);
            writer.WriteVarShort(ContextModif);
        }

        public override void Deserialize(IDataReader reader)
        {
            Base = reader.ReadVarShort();
            Additionnal = reader.ReadVarShort();
            ObjectsAndMountBonus = reader.ReadVarShort();
            AlignGiftBonus = reader.ReadVarShort();
            ContextModif = reader.ReadVarShort();
        }
    }
}