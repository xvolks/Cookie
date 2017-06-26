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
    using Cookie.API.Utils.IO;


    public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        
        public new const uint ProtocolId = 6116;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ushort m_weaponGenericId;
        
        public virtual ushort WeaponGenericId
        {
            get
            {
                return m_weaponGenericId;
            }
            set
            {
                m_weaponGenericId = value;
            }
        }
        
        public GameActionFightCloseCombatMessage(ushort weaponGenericId)
        {
            m_weaponGenericId = weaponGenericId;
        }
        
        public GameActionFightCloseCombatMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(m_weaponGenericId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_weaponGenericId = reader.ReadVarUhShort();
        }
    }
}
