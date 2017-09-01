using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeCrafterJobLevelupMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6598;

        public ExchangeCrafterJobLevelupMessage(byte crafterJobLevel)
        {
            CrafterJobLevel = crafterJobLevel;
        }

        public ExchangeCrafterJobLevelupMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte CrafterJobLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            CrafterJobLevel = reader.ReadByte();
        }
    }
}