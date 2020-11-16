using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterBaseCharacteristic : NetworkType
    {
        public const ushort ProtocolId = 4;

        public override ushort TypeID => ProtocolId;

        public short Base { get; set; }
        public short Additionnal { get; set; }
        public short ObjectsAndMountBonus { get; set; }
        public short AlignGiftBonus { get; set; }
        public short ContextModif { get; set; }
        public CharacterBaseCharacteristic() { }

        public CharacterBaseCharacteristic( short Base, short Additionnal, short ObjectsAndMountBonus, short AlignGiftBonus, short ContextModif ){
            this.Base = Base;
            this.Additionnal = Additionnal;
            this.ObjectsAndMountBonus = ObjectsAndMountBonus;
            this.AlignGiftBonus = AlignGiftBonus;
            this.ContextModif = ContextModif;
        }

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
