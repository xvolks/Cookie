namespace Cookie.Protocol.Network.Types.Game.Friend
{
    using Cookie.IO;

    public class FriendInformations : AbstractContactInformations
    {
        
        public new const short ProtocolId = 78;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private byte m_playerState;
        
        public virtual byte PlayerState
        {
            get
            {
                return m_playerState;
            }
            set
            {
                m_playerState = value;
            }
        }
        
        private ushort m_lastConnection;
        
        public virtual ushort LastConnection
        {
            get
            {
                return m_lastConnection;
            }
            set
            {
                m_lastConnection = value;
            }
        }
        
        private int m_achievementPoints;
        
        public virtual int AchievementPoints
        {
            get
            {
                return m_achievementPoints;
            }
            set
            {
                m_achievementPoints = value;
            }
        }
        
        public FriendInformations(byte playerState, ushort lastConnection, int achievementPoints)
        {
            m_playerState = playerState;
            m_lastConnection = lastConnection;
            m_achievementPoints = achievementPoints;
        }
        
        public FriendInformations()
        {
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
