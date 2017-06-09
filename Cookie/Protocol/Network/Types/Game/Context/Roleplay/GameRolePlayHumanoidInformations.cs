namespace Cookie.Protocol.Network.Types.Game.Context.Roleplay
{
    using Cookie.IO;


    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        
        public new const short ProtocolId = 159;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private HumanInformations m_humanoidInfo;
        
        public virtual HumanInformations HumanoidInfo
        {
            get
            {
                return m_humanoidInfo;
            }
            set
            {
                m_humanoidInfo = value;
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
        
        public GameRolePlayHumanoidInformations(HumanInformations humanoidInfo, int accountId)
        {
            m_humanoidInfo = humanoidInfo;
            m_accountId = accountId;
        }
        
        public GameRolePlayHumanoidInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(((ushort)(m_humanoidInfo.TypeID)));
            m_humanoidInfo.Serialize(writer);
            writer.WriteInt(m_accountId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_humanoidInfo = ProtocolTypeManager.GetInstance<HumanInformations>((short)reader.ReadUShort());
            m_humanoidInfo.Deserialize(reader);
            m_accountId = reader.ReadInt();
        }
    }
}
