using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        public const uint ProtocolId = 6114;
        public override uint MessageID { get { return ProtocolId; } }

        public long CasterId = 0;
        public short TargetCellId = 0;
        public short SpellId = 0;
        public short SpellLevel = 0;

        public GameRolePlaySpellAnimMessage()
        {
        }

        public GameRolePlaySpellAnimMessage(
            long casterId,
            short targetCellId,
            short spellId,
            short spellLevel
        )
        {
            CasterId = casterId;
            TargetCellId = targetCellId;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(CasterId);
            writer.WriteVarShort(TargetCellId);
            writer.WriteVarShort(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CasterId = reader.ReadVarLong();
            TargetCellId = reader.ReadVarShort();
            SpellId = reader.ReadVarShort();
            SpellLevel = reader.ReadShort();
        }
    }
}