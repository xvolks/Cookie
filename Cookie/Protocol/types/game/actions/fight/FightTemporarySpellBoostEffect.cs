using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
    {
        public new const short ProtocolId = 207;
        public override short TypeId { get { return ProtocolId; } }

        public short BoostedSpellId = 0;

        public FightTemporarySpellBoostEffect(): base()
        {
        }

        public FightTemporarySpellBoostEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid,
            short delta,
            short boostedSpellId
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
            BoostedSpellId = boostedSpellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(BoostedSpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            BoostedSpellId = reader.ReadVarShort();
        }
    }
}