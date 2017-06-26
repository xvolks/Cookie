//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    using Cookie.API.Protocol.Network.Types.Game.Look;
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
    {
        
        public new const short ProtocolId = 474;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private byte m_deathState;
        
        public virtual byte DeathState
        {
            get
            {
                return m_deathState;
            }
            set
            {
                m_deathState = value;
            }
        }
        
        private ushort m_deathCount;
        
        public virtual ushort DeathCount
        {
            get
            {
                return m_deathCount;
            }
            set
            {
                m_deathCount = value;
            }
        }
        
        private sbyte m_deathMaxLevel;
        
        public virtual sbyte DeathMaxLevel
        {
            get
            {
                return m_deathMaxLevel;
            }
            set
            {
                m_deathMaxLevel = value;
            }
        }
        
        public CharacterHardcoreOrEpicInformations(byte deathState, ushort deathCount, sbyte deathMaxLevel)
        {
            m_deathState = deathState;
            m_deathCount = deathCount;
            m_deathMaxLevel = deathMaxLevel;
        }
        
        public CharacterHardcoreOrEpicInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(m_deathState);
            writer.WriteVarUhShort(m_deathCount);
            writer.WriteSByte(m_deathMaxLevel);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_deathState = reader.ReadByte();
            m_deathCount = reader.ReadVarUhShort();
            m_deathMaxLevel = reader.ReadSByte();
        }
    }
}
