using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class AbstractContactInformations : NetworkType
    {
        public const short ProtocolId = 380;

        private int m_accountId;

        private string m_accountName;

        public AbstractContactInformations(int accountId, string accountName)
        {
            m_accountId = accountId;
            m_accountName = accountName;
        }

        public AbstractContactInformations()
        {
        }

        public override short TypeID => ProtocolId;

        public virtual int AccountId
        {
            get => m_accountId;
            set => m_accountId = value;
        }

        public virtual string AccountName
        {
            get => m_accountName;
            set => m_accountName = value;
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