namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Utils.IO;

    public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const ushort ProtocolId = 6116;
        public override ushort MessageID => ProtocolId;
        public ushort WeaponGenericId { get; set; }

        public GameActionFightCloseCombatMessage(ushort weaponGenericId)
        {
            WeaponGenericId = weaponGenericId;
        }

        public GameActionFightCloseCombatMessage() { }

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
