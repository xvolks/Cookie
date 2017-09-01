using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
    {
        public new const ushort ProtocolId = 5784;

        public ExchangePlayerMultiCraftRequestMessage(ulong target, uint skillId)
        {
            Target = target;
            SkillId = skillId;
        }

        public ExchangePlayerMultiCraftRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong Target { get; set; }
        public uint SkillId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Target);
            writer.WriteVarUhInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Target = reader.ReadVarUhLong();
            SkillId = reader.ReadVarUhInt();
        }
    }
}