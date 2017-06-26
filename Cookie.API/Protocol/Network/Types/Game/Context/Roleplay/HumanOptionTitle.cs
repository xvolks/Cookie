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
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class HumanOptionTitle : HumanOption
    {
        
        public new const short ProtocolId = 408;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ushort m_titleId;
        
        public virtual ushort TitleId
        {
            get
            {
                return m_titleId;
            }
            set
            {
                m_titleId = value;
            }
        }
        
        private string m_titleParam;
        
        public virtual string TitleParam
        {
            get
            {
                return m_titleParam;
            }
            set
            {
                m_titleParam = value;
            }
        }
        
        public HumanOptionTitle(ushort titleId, string titleParam)
        {
            m_titleId = titleId;
            m_titleParam = titleParam;
        }
        
        public HumanOptionTitle()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(m_titleId);
            writer.WriteUTF(m_titleParam);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_titleId = reader.ReadVarUhShort();
            m_titleParam = reader.ReadUTF();
        }
    }
}
