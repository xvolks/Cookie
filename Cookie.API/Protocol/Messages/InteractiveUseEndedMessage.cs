using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InteractiveUseEndedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6112;

        public override ushort MessageID => ProtocolId;

        public uint ElemId { get; set; }
        public ushort SkillId { get; set; }
        public InteractiveUseEndedMessage() { }

        public InteractiveUseEndedMessage( uint ElemId, ushort SkillId ){
            this.ElemId = ElemId;
            this.SkillId = SkillId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ElemId);
            writer.WriteVarUhShort(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElemId = reader.ReadVarUhInt();
            SkillId = reader.ReadVarUhShort();
        }
    }
}
