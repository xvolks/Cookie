using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTriggeredEffect : AbstractFightDispellableEffect
    {
        public new const short ProtocolId = 210;
        public override short TypeId { get { return ProtocolId; } }

        public int Param1 = 0;
        public int Param2 = 0;
        public int Param3 = 0;
        public short Delay = 0;

        public FightTriggeredEffect(): base()
        {
        }

        public FightTriggeredEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid,
            int param1,
            int param2,
            int param3,
            short delay
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
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Delay = delay;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Param1);
            writer.WriteInt(Param2);
            writer.WriteInt(Param3);
            writer.WriteShort(Delay);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Param1 = reader.ReadInt();
            Param2 = reader.ReadInt();
            Param3 = reader.ReadInt();
            Delay = reader.ReadShort();
        }
    }
}