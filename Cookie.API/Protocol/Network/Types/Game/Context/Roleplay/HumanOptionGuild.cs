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
    
    
    public class HumanOptionGuild : HumanOption
    {
        
        public new const short ProtocolId = 409;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private GuildInformations m_guildInformations;
        
        public virtual GuildInformations GuildInformations
        {
            get
            {
                return m_guildInformations;
            }
            set
            {
                m_guildInformations = value;
            }
        }
        
        public HumanOptionGuild(GuildInformations guildInformations)
        {
            m_guildInformations = guildInformations;
        }
        
        public HumanOptionGuild()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            m_guildInformations.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_guildInformations = new GuildInformations();
            m_guildInformations.Deserialize(reader);
        }
    }
}
