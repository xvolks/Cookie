//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Cookie.API.Protocol.Network.Types.Game.Achievement;
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class AchievementDetailsMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6378;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private Achievement m_achievement;
        
        public virtual Achievement Achievement
        {
            get
            {
                return m_achievement;
            }
            set
            {
                m_achievement = value;
            }
        }
        
        public AchievementDetailsMessage(Achievement achievement)
        {
            m_achievement = achievement;
        }
        
        public AchievementDetailsMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            m_achievement.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_achievement = new Achievement();
            m_achievement.Deserialize(reader);
        }
    }
}
