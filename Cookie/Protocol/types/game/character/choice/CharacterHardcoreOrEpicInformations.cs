using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
    {
        public new const short ProtocolId = 474;
        public override short TypeId { get { return ProtocolId; } }

        public byte DeathState = 0;
        public short DeathCount = 0;
        public short DeathMaxLevel = 0;

        public CharacterHardcoreOrEpicInformations(): base()
        {
        }

        public CharacterHardcoreOrEpicInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            bool sex,
            byte deathState,
            short deathCount,
            short deathMaxLevel
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed,
            sex
        )
        {
            DeathState = deathState;
            DeathCount = deathCount;
            DeathMaxLevel = deathMaxLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(DeathState);
            writer.WriteVarShort(DeathCount);
            writer.WriteVarShort(DeathMaxLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            DeathState = reader.ReadByte();
            DeathCount = reader.ReadVarShort();
            DeathMaxLevel = reader.ReadVarShort();
        }
    }
}