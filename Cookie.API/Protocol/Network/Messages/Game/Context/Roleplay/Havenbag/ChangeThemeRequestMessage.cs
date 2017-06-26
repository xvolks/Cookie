//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class ChangeThemeRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6639;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private byte m_theme;
        
        public virtual byte Theme
        {
            get
            {
                return m_theme;
            }
            set
            {
                m_theme = value;
            }
        }
        
        public ChangeThemeRequestMessage(byte theme)
        {
            m_theme = theme;
        }
        
        public ChangeThemeRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(m_theme);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_theme = reader.ReadByte();
        }
    }
}
