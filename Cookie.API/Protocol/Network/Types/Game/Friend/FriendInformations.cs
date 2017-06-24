using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class FriendInformations : AbstractContactInformations
    {
        public new const short ProtocolId = 78;

        private int m_achievementPoints;

        private ushort m_lastConnection;

        private byte m_playerState;

        public FriendInformations(byte playerState, ushort lastConnection, int achievementPoints)
        {
            m_playerState = playerState;
            m_lastConnection = lastConnection;
            m_achievementPoints = achievementPoints;
        }

        public FriendInformations()
        {
        }

        public override short TypeID => ProtocolId;

        public virtual byte PlayerState
        {
            get => m_playerState;
            set => m_playerState = value;
        }

        public virtual ushort LastConnection
        {
            get => m_lastConnection;
            set => m_lastConnection = value;
        }

        public virtual int AchievementPoints
        {
            get => m_achievementPoints;
            set => m_achievementPoints = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(m_playerState);
            writer.WriteVarUhShort(m_lastConnection);
            writer.WriteInt(m_achievementPoints);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_playerState = reader.ReadByte();
            m_lastConnection = reader.ReadVarUhShort();
            m_achievementPoints = reader.ReadInt();
        }
    }
}