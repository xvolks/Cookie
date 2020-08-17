using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const ushort ProtocolId = 6116;

        public GameActionFightCloseCombatMessage(ushort weaponGenericId)
        {
            WeaponGenericId = weaponGenericId;
        }

        public GameActionFightCloseCombatMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort WeaponGenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(WeaponGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WeaponGenericId = reader.ReadVarUhShort();
        }
    }
}