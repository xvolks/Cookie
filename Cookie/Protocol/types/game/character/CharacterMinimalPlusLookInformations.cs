using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public new const short ProtocolId = 163;
        public override short TypeId { get { return ProtocolId; } }

        public EntityLook EntityLook_;
        public byte Breed = 0;

        public CharacterMinimalPlusLookInformations(): base()
        {
        }

        public CharacterMinimalPlusLookInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed
        ): base(
            id_,
            name,
            level
        )
        {
            EntityLook_ = entityLook_;
            Breed = breed;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            EntityLook_.Serialize(writer);
            writer.WriteByte(Breed);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            EntityLook_ = new EntityLook();
            EntityLook_.Deserialize(reader);
            Breed = reader.ReadByte();
        }
    }
}