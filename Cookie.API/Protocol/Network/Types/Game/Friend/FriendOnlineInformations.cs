using Cookie.API.Protocol.Network.Types.Game.Character.Status;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class FriendOnlineInformations : FriendInformations
    {
        public new const ushort ProtocolId = 92;

        public FriendOnlineInformations(bool sex, bool havenBagShared, ulong playerId, string playerName, byte level,
            sbyte alignmentSide, sbyte breed, GuildInformations guildInfo, ushort moodSmileyId, PlayerStatus status)
        {
            Sex = sex;
            HavenBagShared = havenBagShared;
            PlayerId = playerId;
            PlayerName = playerName;
            Level = level;
            AlignmentSide = alignmentSide;
            Breed = breed;
            GuildInfo = guildInfo;
            MoodSmileyId = moodSmileyId;
            Status = status;
        }

        public FriendOnlineInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool Sex { get; set; }
        public bool HavenBagShared { get; set; }
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public byte Level { get; set; }
        public sbyte AlignmentSide { get; set; }
        public sbyte Breed { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public ushort MoodSmileyId { get; set; }
        public PlayerStatus Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
            flag = BooleanByteWrapper.SetFlag(1, flag, HavenBagShared);
            writer.WriteByte(flag);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteByte(Level);
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(Breed);
            GuildInfo.Serialize(writer);
            writer.WriteVarUhShort(MoodSmileyId);
            writer.WriteUShort(Status.TypeID);
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
            Level = reader.ReadByte();
            AlignmentSide = reader.ReadSByte();
            Breed = reader.ReadSByte();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MoodSmileyId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}