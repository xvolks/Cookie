using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
    {
        public new const short ProtocolId = 209;
        public override short TypeId { get { return ProtocolId; } }

        public short Delta = 0;

        public FightTemporaryBoostEffect(): base()
        {
        }

        public FightTemporaryBoostEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid,
            short delta
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
            Delta = delta;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Delta);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Delta = reader.ReadShort();
        }
    }
}