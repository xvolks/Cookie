using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
    {
        public new const short ProtocolId = 211;
        public override short TypeId { get { return ProtocolId; } }

        public short WeaponTypeId = 0;

        public FightTemporaryBoostWeaponDamagesEffect(): base()
        {
        }

        public FightTemporaryBoostWeaponDamagesEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid,
            short delta,
            short weaponTypeId
        ): base(
            uid,
            targetId,
            turnDuration,
            dispelable,
            spellId,
            effectId,
            parentBoostUid,
            delta
        )
        {
            WeaponTypeId = weaponTypeId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WeaponTypeId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WeaponTypeId = reader.ReadShort();
        }
    }
}