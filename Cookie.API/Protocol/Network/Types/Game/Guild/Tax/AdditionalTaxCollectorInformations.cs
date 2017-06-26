//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class AdditionalTaxCollectorInformations : NetworkType
    {
        
        public const short ProtocolId = 165;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private string m_collectorCallerName;
        
        public virtual string CollectorCallerName
        {
            get
            {
                return m_collectorCallerName;
            }
            set
            {
                m_collectorCallerName = value;
            }
        }
        
        private int m_date;
        
        public virtual int Date
        {
            get
            {
                return m_date;
            }
            set
            {
                m_date = value;
            }
        }
        
        public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
        {
            m_collectorCallerName = collectorCallerName;
            m_date = date;
        }
        
        public AdditionalTaxCollectorInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(m_collectorCallerName);
            writer.WriteInt(m_date);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_collectorCallerName = reader.ReadUTF();
            m_date = reader.ReadInt();
        }
    }
}
