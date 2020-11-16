using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
    {
        public new const uint ProtocolId = 5784;
        public override uint MessageID { get { return ProtocolId; } }

        public long Target = 0;
        public int SkillId = 0;

        public ExchangePlayerMultiCraftRequestMessage(): base()
        {
        }

        public ExchangePlayerMultiCraftRequestMessage(
            byte exchangeType,
            long target,
            int skillId
        ): base(
            exchangeType
        )
        {
            Target = target;
            SkillId = skillId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Target);
            writer.WriteVarInt(SkillId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Target = reader.ReadVarLong();
            SkillId = reader.ReadVarInt();
        }
    }
}