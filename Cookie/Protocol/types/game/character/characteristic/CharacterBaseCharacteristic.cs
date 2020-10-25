using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterBaseCharacteristic : NetworkType
    {
        public const short ProtocolId = 4;
        public override short TypeId { get { return ProtocolId; } }

        public short Base_ = 0;
        public short Additionnal = 0;
        public short ObjectsAndMountBonus = 0;
        public short AlignGiftBonus = 0;
        public short ContextModif = 0;

        public CharacterBaseCharacteristic()
        {
        }

        public CharacterBaseCharacteristic(
            short base_,
            short additionnal,
            short objectsAndMountBonus,
            short alignGiftBonus,
            short contextModif
        )
        {
            Base_ = base_;
            Additionnal = additionnal;
            ObjectsAndMountBonus = objectsAndMountBonus;
            AlignGiftBonus = alignGiftBonus;
            ContextModif = contextModif;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Base_);
            writer.WriteVarShort(Additionnal);
            writer.WriteVarShort(ObjectsAndMountBonus);
            writer.WriteVarShort(AlignGiftBonus);
            writer.WriteVarShort(ContextModif);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Base_ = reader.ReadVarShort();
            Additionnal = reader.ReadVarShort();
            ObjectsAndMountBonus = reader.ReadVarShort();
            AlignGiftBonus = reader.ReadVarShort();
            ContextModif = reader.ReadVarShort();
        }
    }
}