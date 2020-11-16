using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
    {
        public new const short ProtocolId = 214;
        public override short TypeId { get { return ProtocolId; } }

        public short StateId = 0;

        public FightTemporaryBoostStateEffect(): base()
        {
        }

        public FightTemporaryBoostStateEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid,
            short delta,
            short stateId
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
            StateId = stateId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(StateId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            StateId = reader.ReadShort();
        }
    }
}