using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
    {
        public new const ushort ProtocolId = 5941;

        public ExchangeStartOkCraftWithInformationMessage(uint skillId)
        {
            SkillId = skillId;
        }

        public ExchangeStartOkCraftWithInformationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint SkillId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SkillId = reader.ReadVarUhInt();
        }
    }
}