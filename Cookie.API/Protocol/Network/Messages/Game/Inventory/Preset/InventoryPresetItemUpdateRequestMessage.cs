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
    
    
    public class InventoryPresetItemUpdateRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6210;
        
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
        
        private sbyte m_position;
        
        public virtual sbyte Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
            }
        }
        
        private uint m_objUid;
        
        public virtual uint ObjUid
        {
            get
            {
                return m_objUid;
            }
            set
            {
                m_objUid = value;
            }
        }
        
        public InventoryPresetItemUpdateRequestMessage(byte presetId, sbyte position, uint objUid)
        {
            m_presetId = presetId;
            m_position = position;
            m_objUid = objUid;
        }
        
        public InventoryPresetItemUpdateRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(m_presetId);
            writer.WriteSByte(m_position);
            writer.WriteVarUhInt(m_objUid);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_presetId = reader.ReadByte();
            m_position = reader.ReadSByte();
            m_objUid = reader.ReadVarUhInt();
        }
    }
}
