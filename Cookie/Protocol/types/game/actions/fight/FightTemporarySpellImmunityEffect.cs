using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
    {
        public new const short ProtocolId = 366;
        public override short TypeId { get { return ProtocolId; } }

        public int ImmuneSpellId = 0;

        public FightTemporarySpellImmunityEffect(): base()
        {
        }

        public FightTemporarySpellImmunityEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid,
            int immuneSpellId
        ): base(
            uid,
            targetId,
            turnDuration,
            dispelable,
            spellId,
            effectId,
            parentBoostUid
        )
        {
            ImmuneSpellId = immuneSpellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ImmuneSpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ImmuneSpellId = reader.ReadInt();
        }
    }
}