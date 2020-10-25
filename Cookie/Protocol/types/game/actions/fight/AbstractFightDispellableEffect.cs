using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AbstractFightDispellableEffect : NetworkType
    {
        public const short ProtocolId = 206;
        public override short TypeId { get { return ProtocolId; } }

        public int Uid = 0;
        public double TargetId = 0;
        public short TurnDuration = 0;
        public byte Dispelable = 1;
        public short SpellId = 0;
        public int EffectId = 0;
        public int ParentBoostUid = 0;

        public AbstractFightDispellableEffect()
        {
        }

        public AbstractFightDispellableEffect(
            int uid,
            double targetId,
            short turnDuration,
            byte dispelable,
            short spellId,
            int effectId,
            int parentBoostUid
        )
        {
            Uid = uid;
            TargetId = targetId;
            TurnDuration = turnDuration;
            Dispelable = dispelable;
            SpellId = spellId;
            EffectId = effectId;
            ParentBoostUid = parentBoostUid;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Uid);
            writer.WriteDouble(TargetId);
            writer.WriteShort(TurnDuration);
            writer.WriteByte(Dispelable);
            writer.WriteVarShort(SpellId);
            writer.WriteVarInt(EffectId);
            writer.WriteVarInt(ParentBoostUid);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Uid = reader.ReadVarInt();
            TargetId = reader.ReadDouble();
            TurnDuration = reader.ReadShort();
            Dispelable = reader.ReadByte();
            SpellId = reader.ReadVarShort();
            EffectId = reader.ReadVarInt();
            ParentBoostUid = reader.ReadVarInt();
        }
    }
}