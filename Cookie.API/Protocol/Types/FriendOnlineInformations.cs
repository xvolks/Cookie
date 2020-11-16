using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FriendOnlineInformations : FriendInformations
    {
        public new const ushort ProtocolId = 92;

        public override ushort TypeID => ProtocolId;

        public bool Sex { get; set; }
        public bool HavenBagShared { get; set; }
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public ushort Level { get; set; }
        public sbyte AlignmentSide { get; set; }
        public sbyte Breed { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public ushort MoodSmileyId { get; set; }
        public PlayerStatus Status { get; set; }
        public FriendOnlineInformations() { }

        public FriendOnlineInformations( bool Sex, bool HavenBagShared, ulong PlayerId, string PlayerName, ushort Level, sbyte AlignmentSide, sbyte Breed, GuildInformations GuildInfo, ushort MoodSmileyId, PlayerStatus Status ){
            this.Sex = Sex;
            this.HavenBagShared = HavenBagShared;
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
            this.Level = Level;
            this.AlignmentSide = AlignmentSide;
            this.Breed = Breed;
            this.GuildInfo = GuildInfo;
            this.MoodSmileyId = MoodSmileyId;
            this.Status = Status;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
			flag = BooleanByteWrapper.SetFlag(1, flag, HavenBagShared);
			writer.WriteByte(flag);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarUhShort(Level);
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(Breed);
            GuildInfo.Serialize(writer);
            writer.WriteVarUhShort(MoodSmileyId);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
			var flag = reader.ReadByte();
			Sex = BooleanByteWrapper.GetFlag(flag, 0);
			HavenBagShared = BooleanByteWrapper.GetFlag(flag, 1);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            Level = reader.ReadVarUhShort();
            AlignmentSide = reader.ReadSByte();
            Breed = reader.ReadSByte();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MoodSmileyId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}
