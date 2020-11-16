using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InteractiveUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5001;

        public override ushort MessageID => ProtocolId;

        public uint ElemId { get; set; }
        public uint SkillInstanceUid { get; set; }
        public InteractiveUseRequestMessage() { }

        public InteractiveUseRequestMessage( uint ElemId, uint SkillInstanceUid ){
            this.ElemId = ElemId;
            this.SkillInstanceUid = SkillInstanceUid;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ElemId);
            writer.WriteVarUhInt(SkillInstanceUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElemId = reader.ReadVarUhInt();
            SkillInstanceUid = reader.ReadVarUhInt();
        }
    }
}
