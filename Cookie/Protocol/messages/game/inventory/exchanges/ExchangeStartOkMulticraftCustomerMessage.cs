using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkMulticraftCustomerMessage : NetworkMessage
    {
        public const uint ProtocolId = 5817;
        public override uint MessageID { get { return ProtocolId; } }

        public int SkillId = 0;
        public byte CrafterJobLevel = 0;

        public ExchangeStartOkMulticraftCustomerMessage()
        {
        }

        public ExchangeStartOkMulticraftCustomerMessage(
            int skillId,
            byte crafterJobLevel
        )
        {
            SkillId = skillId;
            CrafterJobLevel = crafterJobLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(SkillId);
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SkillId = reader.ReadVarInt();
            CrafterJobLevel = reader.ReadByte();
        }
    }
}