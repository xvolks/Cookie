namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    using Utils.IO;

    public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
    {
        public new const ushort ProtocolId = 211;
        public override ushort TypeID => ProtocolId;
        public short WeaponTypeId { get; set; }

        public FightTemporaryBoostWeaponDamagesEffect(short weaponTypeId)
        {
            WeaponTypeId = weaponTypeId;
        }

        public FightTemporaryBoostWeaponDamagesEffect() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WeaponTypeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WeaponTypeId = reader.ReadShort();
        }

    }
}
