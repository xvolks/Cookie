using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class FriendSpouseInformations : NetworkType
    {
        public const ushort ProtocolId = 77;

        public FriendSpouseInformations(int spouseAccountId, ulong spouseId, string spouseName, byte spouseLevel,
            sbyte breed, sbyte sex, EntityLook spouseEntityLook, GuildInformations guildInfo, sbyte alignmentSide)
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

        public FriendSpouseInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int SpouseAccountId { get; set; }
        public ulong SpouseId { get; set; }
        public string SpouseName { get; set; }
        public byte SpouseLevel { get; set; }
        public sbyte Breed { get; set; }
        public sbyte Sex { get; set; }
        public EntityLook SpouseEntityLook { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public sbyte AlignmentSide { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpouseAccountId);
            writer.WriteVarUhLong(SpouseId);
            writer.WriteUTF(SpouseName);
            writer.WriteByte(SpouseLevel);
            writer.WriteSByte(Breed);
            writer.WriteSByte(Sex);
            SpouseEntityLook.Serialize(writer);
            GuildInfo.Serialize(writer);
            writer.WriteSByte(AlignmentSide);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpouseAccountId = reader.ReadInt();
            SpouseId = reader.ReadVarUhLong();
            SpouseName = reader.ReadUTF();
            SpouseLevel = reader.ReadByte();
            Breed = reader.ReadSByte();
            Sex = reader.ReadSByte();
            SpouseEntityLook = new EntityLook();
            SpouseEntityLook.Deserialize(reader);
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            AlignmentSide = reader.ReadSByte();
        }
    }
}