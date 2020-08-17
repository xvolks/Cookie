using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5818;

        public ExchangeStartOkMulticraftCrafterMessage(uint skillId)
        {
            SkillId = skillId;
        }

        public ExchangeStartOkMulticraftCrafterMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint SkillId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUhInt();
        }
    }
}