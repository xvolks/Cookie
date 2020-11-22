using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FriendSpouseInformations : NetworkType
    {
        public const ushort ProtocolId = 77;

        public override ushort TypeID => ProtocolId;

        public int SpouseAccountId { get; set; }
        public ulong SpouseId { get; set; }
        public string SpouseName { get; set; }
        public ushort SpouseLevel { get; set; }
        public sbyte Breed { get; set; }
        public sbyte Sex { get; set; }
        public EntityLook SpouseEntityLook { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public sbyte AlignmentSide { get; set; }
        public FriendSpouseInformations() { }

        public FriendSpouseInformations( int SpouseAccountId, ulong SpouseId, string SpouseName, ushort SpouseLevel, sbyte Breed, sbyte Sex, EntityLook SpouseEntityLook, GuildInformations GuildInfo, sbyte AlignmentSide ){
            this.SpouseAccountId = SpouseAccountId;
            this.SpouseId = SpouseId;
            this.SpouseName = SpouseName;
            this.SpouseLevel = SpouseLevel;
            this.Breed = Breed;
            this.Sex = Sex;
            this.SpouseEntityLook = SpouseEntityLook;
            this.GuildInfo = GuildInfo;
            this.AlignmentSide = AlignmentSide;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpouseAccountId);
            writer.WriteVarUhLong(SpouseId);
            writer.WriteUTF(SpouseName);
            writer.WriteVarUhShort(SpouseLevel);
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
            SpouseLevel = reader.ReadVarUhShort();
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
