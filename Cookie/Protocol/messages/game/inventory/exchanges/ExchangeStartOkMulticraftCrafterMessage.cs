using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
    {
        public const uint ProtocolId = 5818;
        public override uint MessageID { get { return ProtocolId; } }

        public int SkillId = 0;

        public ExchangeStartOkMulticraftCrafterMessage()
        {
        }

        public ExchangeStartOkMulticraftCrafterMessage(
            int skillId
        )
        {
            SkillId = skillId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(SkillId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SkillId = reader.ReadVarInt();
        }
    }
}