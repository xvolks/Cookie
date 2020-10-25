using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FriendSpouseInformations : NetworkType
    {
        public const short ProtocolId = 77;
        public override short TypeId { get { return ProtocolId; } }

        public int SpouseAccountId = 0;
        public long SpouseId = 0;
        public string SpouseName;
        public short SpouseLevel = 0;
        public byte Breed = 0;
        public byte Sex = 0;
        public EntityLook SpouseEntityLook;
        public GuildInformations GuildInfo;
        public byte AlignmentSide = 0;

        public FriendSpouseInformations()
        {
        }

        public FriendSpouseInformations(
            int spouseAccountId,
            long spouseId,
            string spouseName,
            short spouseLevel,
            byte breed,
            byte sex,
            EntityLook spouseEntityLook,
            GuildInformations guildInfo,
            byte alignmentSide
        )
        {
            SpouseAccountId = spouseAccountId;
            SpouseId = spouseId;
            SpouseName = spouseName;
            SpouseLevel = spouseLevel;
            Breed = breed;
            Sex = sex;
            SpouseEntityLook = spouseEntityLook;
            GuildInfo = guildInfo;
            AlignmentSide = alignmentSide;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(SpouseAccountId);
            writer.WriteVarLong(SpouseId);
            writer.WriteUTF(SpouseName);
            writer.WriteVarShort(SpouseLevel);
            writer.WriteByte(Breed);
            writer.WriteByte(Sex);
            SpouseEntityLook.Serialize(writer);
            GuildInfo.Serialize(writer);
            writer.WriteByte(AlignmentSide);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpouseAccountId = reader.ReadInt();
            SpouseId = reader.ReadVarLong();
            SpouseName = reader.ReadUTF();
            SpouseLevel = reader.ReadVarShort();
            Breed = reader.ReadByte();
            Sex = reader.ReadByte();
            SpouseEntityLook = new EntityLook();
            SpouseEntityLook.Deserialize(reader);
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            AlignmentSide = reader.ReadByte();
        }
    }
}