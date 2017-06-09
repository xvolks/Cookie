namespace Cookie.Protocol.Network.Types.Game.Friend
{
    using Cookie.IO;

    public class AbstractContactInformations : NetworkType
    {
        
        public const short ProtocolId = 380;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private int m_accountId;
        
        public virtual int AccountId
        {
            get
            {
                return m_accountId;
            }
            set
            {
                m_accountId = value;
            }
        }
        
        private string m_accountName;
        
        public virtual string AccountName
        {
            get
            {
                return m_accountName;
            }
            set
            {
                m_accountName = value;
            }
        }
        
        public AbstractContactInformations(int accountId, string accountName)
        {
            m_accountId = accountId;
            m_accountName = accountName;
        }
        
        public AbstractContactInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(m_accountId);
            writer.WriteUTF(m_accountName);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_accountId = reader.ReadInt();
            m_accountName = reader.ReadUTF();
        }
    }
}
