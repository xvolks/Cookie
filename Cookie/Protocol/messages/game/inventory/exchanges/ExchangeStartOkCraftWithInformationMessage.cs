using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
    {
        public new const uint ProtocolId = 5941;
        public override uint MessageID { get { return ProtocolId; } }

        public int SkillId = 0;

        public ExchangeStartOkCraftWithInformationMessage(): base()
        {
        }

        public ExchangeStartOkCraftWithInformationMessage(
            int skillId
        ): base()
        {
            SkillId = skillId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(SkillId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SkillId = reader.ReadVarInt();
        }
    }
}