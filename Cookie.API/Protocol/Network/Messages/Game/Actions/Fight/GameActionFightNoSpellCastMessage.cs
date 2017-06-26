//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6132;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private uint m_spellLevelId;
        
        public virtual uint SpellLevelId
        {
            get
            {
                return m_spellLevelId;
            }
            set
            {
                m_spellLevelId = value;
            }
        }
        
        public GameActionFightNoSpellCastMessage(uint spellLevelId)
        {
            m_spellLevelId = spellLevelId;
        }
        
        public GameActionFightNoSpellCastMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhInt(m_spellLevelId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_spellLevelId = reader.ReadVarUhInt();
        }
    }
}
