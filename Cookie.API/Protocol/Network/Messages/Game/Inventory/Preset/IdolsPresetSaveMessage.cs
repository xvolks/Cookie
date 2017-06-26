//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class IdolsPresetSaveMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6603;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private byte m_presetId;
        
        public virtual byte PresetId
        {
            get
            {
                return m_presetId;
            }
            set
            {
                m_presetId = value;
            }
        }
        
        private byte m_symbolId;
        
        public virtual byte SymbolId
        {
            get
            {
                return m_symbolId;
            }
            set
            {
                m_symbolId = value;
            }
        }
        
        public IdolsPresetSaveMessage(byte presetId, byte symbolId)
        {
            m_presetId = presetId;
            m_symbolId = symbolId;
        }
        
        public IdolsPresetSaveMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(m_presetId);
            writer.WriteByte(m_symbolId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_presetId = reader.ReadByte();
            m_symbolId = reader.ReadByte();
        }
    }
}
