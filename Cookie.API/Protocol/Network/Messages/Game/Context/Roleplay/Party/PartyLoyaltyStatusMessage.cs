//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class PartyLoyaltyStatusMessage : AbstractPartyMessage
    {
        
        public new const uint ProtocolId = 6270;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_loyal;
        
        public virtual bool Loyal
        {
            get
            {
                return m_loyal;
            }
            set
            {
                m_loyal = value;
            }
        }
        
        public PartyLoyaltyStatusMessage(bool loyal)
        {
            m_loyal = loyal;
        }
        
        public PartyLoyaltyStatusMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(m_loyal);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_loyal = reader.ReadBoolean();
        }
    }
}
