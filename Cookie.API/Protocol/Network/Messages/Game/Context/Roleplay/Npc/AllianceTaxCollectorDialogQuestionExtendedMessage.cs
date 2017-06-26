//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
    {
        
        public new const uint ProtocolId = 6445;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private BasicNamedAllianceInformations m_alliance;
        
        public virtual BasicNamedAllianceInformations Alliance
        {
            get
            {
                return m_alliance;
            }
            set
            {
                m_alliance = value;
            }
        }
        
        public AllianceTaxCollectorDialogQuestionExtendedMessage(BasicNamedAllianceInformations alliance)
        {
            m_alliance = alliance;
        }
        
        public AllianceTaxCollectorDialogQuestionExtendedMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            m_alliance.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_alliance = new BasicNamedAllianceInformations();
            m_alliance.Deserialize(reader);
        }
    }
}
