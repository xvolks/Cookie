//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Cookie.API.Utils.IO;


    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        
        public new const short ProtocolId = 3;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ushort m_monsterId;
        
        public virtual ushort MonsterId
        {
            get
            {
                return m_monsterId;
            }
            set
            {
                m_monsterId = value;
            }
        }
        
        private byte m_powerLevel;
        
        public virtual byte PowerLevel
        {
            get
            {
                return m_powerLevel;
            }
            set
            {
                m_powerLevel = value;
            }
        }
        
        public GameRolePlayMutantInformations(ushort monsterId, byte powerLevel)
        {
            m_monsterId = monsterId;
            m_powerLevel = powerLevel;
        }
        
        public GameRolePlayMutantInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(m_monsterId);
            writer.WriteByte(m_powerLevel);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_monsterId = reader.ReadVarUhShort();
            m_powerLevel = reader.ReadByte();
        }
    }
}
