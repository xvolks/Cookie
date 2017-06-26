//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Cookie.API.Utils.IO;


    public class IdentificationAccountForceMessage : IdentificationMessage
    {
        
        public new const uint ProtocolId = 6119;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private string m_forcedAccountLogin;
        
        public virtual string ForcedAccountLogin
        {
            get
            {
                return m_forcedAccountLogin;
            }
            set
            {
                m_forcedAccountLogin = value;
            }
        }
        
        public IdentificationAccountForceMessage(string forcedAccountLogin)
        {
            m_forcedAccountLogin = forcedAccountLogin;
        }
        
        public IdentificationAccountForceMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(m_forcedAccountLogin);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_forcedAccountLogin = reader.ReadUTF();
        }
    }
}
