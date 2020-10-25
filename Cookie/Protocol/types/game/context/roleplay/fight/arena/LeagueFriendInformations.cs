using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class LeagueFriendInformations : AbstractContactInformations
    {
        public new const short ProtocolId = 555;
        public override short TypeId { get { return ProtocolId; } }

        public long PlayerId = 0;
        public string PlayerName;
        public byte Breed = 0;
        public bool Sex = false;
        public short Level = 0;
        public short LeagueId = 0;
        public short TotalLeaguePoints = 0;
        public int LadderPosition = 0;

        public LeagueFriendInformations(): base()
        {
        }

        public LeagueFriendInformations(
            int accountId,
            string accountName,
            long playerId,
            string playerName,
            byte breed,
            bool sex,
            short level,
            short leagueId,
            short totalLeaguePoints,
            int ladderPosition
        ): base(
            accountId,
            accountName
        )
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Breed = breed;
            Sex = sex;
            Level = level;
            LeagueId = leagueId;
            TotalLeaguePoints = totalLeaguePoints;
            LadderPosition = ladderPosition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarShort(Level);
            writer.WriteVarShort(LeagueId);
            writer.WriteVarShort(TotalLeaguePoints);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
            Level = reader.ReadVarShort();
            LeagueId = reader.ReadVarShort();
            TotalLeaguePoints = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}