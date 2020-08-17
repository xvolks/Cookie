using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class AbstractFightDispellableEffect : NetworkType
    {
        public const ushort ProtocolId = 206;

        public AbstractFightDispellableEffect(uint uid, double targetId, short turnDuration, byte dispelable,
            ushort spellId, uint effectId, uint parentBoostUid)
        {
            Uid = uid;
            TargetId = targetId;
            TurnDuration = turnDuration;
            Dispelable = dispelable;
            SpellId = spellId;
            EffectId = effectId;
            ParentBoostUid = parentBoostUid;
        }

        public AbstractFightDispellableEffect()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint Uid { get; set; }
        public double TargetId { get; set; }
        public short TurnDuration { get; set; }
        public byte Dispelable { get; set; }
        public ushort SpellId { get; set; }
        public uint EffectId { get; set; }
        public uint ParentBoostUid { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteDouble(TargetId);
            writer.WriteShort(TurnDuration);
            writer.WriteByte(Dispelable);
            writer.WriteVarUhShort(SpellId);
            writer.WriteVarUhInt(EffectId);
            writer.WriteVarUhInt(ParentBoostUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            TargetId = reader.ReadDouble();
            TurnDuration = reader.ReadShort();
            Dispelable = reader.ReadByte();
            SpellId = reader.ReadVarUhShort();
            EffectId = reader.ReadVarUhInt();
            ParentBoostUid = reader.ReadVarUhInt();
        }
    }
}