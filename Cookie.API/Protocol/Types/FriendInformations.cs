using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FriendInformations : AbstractContactInformations
    {
        public new const ushort ProtocolId = 78;

        public override ushort TypeID => ProtocolId;

        public sbyte PlayerState { get; set; }
        public ushort LastConnection { get; set; }
        public int AchievementPoints { get; set; }
        public short LeagueId { get; set; }
        public int LadderPosition { get; set; }
        public FriendInformations() { }

        public FriendInformations( sbyte PlayerState, ushort LastConnection, int AchievementPoints, short LeagueId, int LadderPosition ){
            this.PlayerState = PlayerState;
            this.LastConnection = LastConnection;
            this.AchievementPoints = AchievementPoints;
            this.LeagueId = LeagueId;
            this.LadderPosition = LadderPosition;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PlayerState);
            writer.WriteVarUhShort(LastConnection);
            writer.WriteInt(AchievementPoints);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerState = reader.ReadSByte();
            LastConnection = reader.ReadVarUhShort();
            AchievementPoints = reader.ReadInt();
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}
