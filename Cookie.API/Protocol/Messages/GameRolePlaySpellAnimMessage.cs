using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6114;

        public override ushort MessageID => ProtocolId;

        public ulong CasterId { get; set; }
        public ushort TargetCellId { get; set; }
        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }
        public GameRolePlaySpellAnimMessage() { }

        public GameRolePlaySpellAnimMessage( ulong CasterId, ushort TargetCellId, ushort SpellId, short SpellLevel ){
            this.CasterId = CasterId;
            this.TargetCellId = TargetCellId;
            this.SpellId = SpellId;
            this.SpellLevel = SpellLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CasterId);
            writer.WriteVarUhShort(TargetCellId);
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            CasterId = reader.ReadVarUhLong();
            TargetCellId = reader.ReadVarUhShort();
            SpellId = reader.ReadVarUhShort();
            SpellLevel = reader.ReadShort();
        }
    }
}
