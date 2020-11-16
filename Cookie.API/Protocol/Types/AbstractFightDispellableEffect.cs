using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AbstractFightDispellableEffect : NetworkType
    {
        public const ushort ProtocolId = 206;

        public override ushort TypeID => ProtocolId;

        public uint Uid { get; set; }
        public double TargetId { get; set; }
        public short TurnDuration { get; set; }
        public sbyte Dispelable { get; set; }
        public ushort SpellId { get; set; }
        public uint EffectId { get; set; }
        public uint ParentBoostUid { get; set; }
        public AbstractFightDispellableEffect() { }

        public AbstractFightDispellableEffect( uint Uid, double TargetId, short TurnDuration, sbyte Dispelable, ushort SpellId, uint EffectId, uint ParentBoostUid ){
            this.Uid = Uid;
            this.TargetId = TargetId;
            this.TurnDuration = TurnDuration;
            this.Dispelable = Dispelable;
            this.SpellId = SpellId;
            this.EffectId = EffectId;
            this.ParentBoostUid = ParentBoostUid;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteDouble(TargetId);
            writer.WriteShort(TurnDuration);
            writer.WriteSByte(Dispelable);
            writer.WriteVarUhShort(SpellId);
            writer.WriteVarUhInt(EffectId);
            writer.WriteVarUhInt(ParentBoostUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            TargetId = reader.ReadDouble();
            TurnDuration = reader.ReadShort();
            Dispelable = reader.ReadSByte();
            SpellId = reader.ReadVarUhShort();
            EffectId = reader.ReadVarUhInt();
            ParentBoostUid = reader.ReadVarUhInt();
        }
    }
}
