using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class LeagueFriendInformations : AbstractContactInformations
    {
        public new const ushort ProtocolId = 555;

        public override ushort TypeID => ProtocolId;

        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort Level { get; set; }
        public short LeagueId { get; set; }
        public short TotalLeaguePoints { get; set; }
        public int LadderPosition { get; set; }
        public LeagueFriendInformations() { }

        public LeagueFriendInformations( ulong PlayerId, string PlayerName, sbyte Breed, bool Sex, ushort Level, short LeagueId, short TotalLeaguePoints, int LadderPosition ){
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
            this.Breed = Breed;
            this.Sex = Sex;
            this.Level = Level;
            this.LeagueId = LeagueId;
            this.TotalLeaguePoints = TotalLeaguePoints;
            this.LadderPosition = LadderPosition;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(Level);
            writer.WriteVarShort(LeagueId);
            writer.WriteVarShort(TotalLeaguePoints);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Level = reader.ReadVarUhShort();
            LeagueId = reader.ReadVarShort();
            TotalLeaguePoints = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}
