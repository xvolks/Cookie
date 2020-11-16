using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InteractiveUseEndedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6112;
        public override uint MessageID { get { return ProtocolId; } }

        public int ElemId = 0;
        public short SkillId = 0;

        public InteractiveUseEndedMessage()
        {
        }

        public InteractiveUseEndedMessage(
            int elemId,
            short skillId
        )
        {
            ElemId = elemId;
            SkillId = skillId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ElemId);
            writer.WriteVarShort(SkillId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ElemId = reader.ReadVarInt();
            SkillId = reader.ReadVarShort();
        }
    }
}