using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeCraftResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5790;

        public ExchangeCraftResultMessage(byte craftResult)
        {
            CraftResult = craftResult;
        }

        public ExchangeCraftResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte CraftResult { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(CraftResult);
        }

        public override void Deserialize(IDataReader reader)
        {
            CraftResult = reader.ReadByte();
        }
    }
}