//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Cookie.API.Protocol.Network.Types.Game.Character.Characteristic;
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class FighterStatsListMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6322;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private CharacterCharacteristicsInformations m_stats;
        
        public virtual CharacterCharacteristicsInformations Stats
        {
            get
            {
                return m_stats;
            }
            set
            {
                m_stats = value;
            }
        }
        
        public FighterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            m_stats = stats;
        }
        
        public FighterStatsListMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            m_stats.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_stats = new CharacterCharacteristicsInformations();
            m_stats.Deserialize(reader);
        }
    }
}
