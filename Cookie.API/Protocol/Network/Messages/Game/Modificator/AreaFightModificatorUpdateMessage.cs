//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Modificator
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class AreaFightModificatorUpdateMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6493;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private int m_spellPairId;
        
        public virtual int SpellPairId
        {
            get
            {
                return m_spellPairId;
            }
            set
            {
                m_spellPairId = value;
            }
        }
        
        public AreaFightModificatorUpdateMessage(int spellPairId)
        {
            m_spellPairId = spellPairId;
        }
        
        public AreaFightModificatorUpdateMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(m_spellPairId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_spellPairId = reader.ReadInt();
        }
    }
}
