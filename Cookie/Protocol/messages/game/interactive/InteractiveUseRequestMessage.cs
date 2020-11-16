using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InteractiveUseRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5001;
        public override uint MessageID { get { return ProtocolId; } }

        public int ElemId = 0;
        public int SkillInstanceUid = 0;

        public InteractiveUseRequestMessage()
        {
        }

        public InteractiveUseRequestMessage(
            int elemId,
            int skillInstanceUid
        )
        {
            ElemId = elemId;
            SkillInstanceUid = skillInstanceUid;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ElemId);
            writer.WriteVarInt(SkillInstanceUid);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ElemId = reader.ReadVarInt();
            SkillInstanceUid = reader.ReadVarInt();
        }
    }
}