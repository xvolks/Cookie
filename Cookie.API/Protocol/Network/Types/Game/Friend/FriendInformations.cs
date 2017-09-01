using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class FriendInformations : AbstractContactInformations
    {
        public new const ushort ProtocolId = 78;

        public FriendInformations(byte playerState, ushort lastConnection, int achievementPoints)
        {
            PlayerState = playerState;
            LastConnection = lastConnection;
            AchievementPoints = achievementPoints;
        }

        public FriendInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte PlayerState { get; set; }
        public ushort LastConnection { get; set; }
        public int AchievementPoints { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PlayerState);
            writer.WriteVarUhShort(LastConnection);
            writer.WriteInt(AchievementPoints);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerState = reader.ReadByte();
            LastConnection = reader.ReadVarUhShort();
            AchievementPoints = reader.ReadInt();
        }
    }
}