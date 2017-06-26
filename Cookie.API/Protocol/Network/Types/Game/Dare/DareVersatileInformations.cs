//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Types.Game.Dare
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class DareVersatileInformations : NetworkType
    {
        
        public const short ProtocolId = 504;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private double m_dareId;
        
        public virtual double DareId
        {
            get
            {
                return m_dareId;
            }
            set
            {
                m_dareId = value;
            }
        }
        
        private int m_countEntrants;
        
        public virtual int CountEntrants
        {
            get
            {
                return m_countEntrants;
            }
            set
            {
                m_countEntrants = value;
            }
        }
        
        private int m_countWinners;
        
        public virtual int CountWinners
        {
            get
            {
                return m_countWinners;
            }
            set
            {
                m_countWinners = value;
            }
        }
        
        public DareVersatileInformations(double dareId, int countEntrants, int countWinners)
        {
            m_dareId = dareId;
            m_countEntrants = countEntrants;
            m_countWinners = countWinners;
        }
        
        public DareVersatileInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(m_dareId);
            writer.WriteInt(m_countEntrants);
            writer.WriteInt(m_countWinners);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_dareId = reader.ReadDouble();
            m_countEntrants = reader.ReadInt();
            m_countWinners = reader.ReadInt();
        }
    }
}
