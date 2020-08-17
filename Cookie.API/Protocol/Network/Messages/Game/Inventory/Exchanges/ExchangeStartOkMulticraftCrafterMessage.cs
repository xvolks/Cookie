namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5818;
        public override ushort MessageID => ProtocolId;
        public uint SkillId { get; set; }

        public ExchangeStartOkMulticraftCrafterMessage(uint skillId)
        {
            SkillId = skillId;
        }

        public ExchangeStartOkMulticraftCrafterMessage() { }

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
