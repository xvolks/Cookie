using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InteractiveUsedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5745;

        public override ushort MessageID => ProtocolId;

        public ulong EntityId { get; set; }
        public uint ElemId { get; set; }
        public ushort SkillId { get; set; }
        public ushort Duration { get; set; }
        public bool CanMove { get; set; }
        public InteractiveUsedMessage() { }

        public InteractiveUsedMessage( ulong EntityId, uint ElemId, ushort SkillId, ushort Duration, bool CanMove ){
            this.EntityId = EntityId;
            this.ElemId = ElemId;
            this.SkillId = SkillId;
            this.Duration = Duration;
            this.CanMove = CanMove;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(EntityId);
            writer.WriteVarUhInt(ElemId);
            writer.WriteVarUhShort(SkillId);
            writer.WriteVarUhShort(Duration);
            writer.WriteBoolean(CanMove);
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadVarUhLong();
            ElemId = reader.ReadVarUhInt();
            SkillId = reader.ReadVarUhShort();
            Duration = reader.ReadVarUhShort();
            CanMove = reader.ReadBoolean();
        }
    }
}
