using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeObjectMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5515;

        public ExchangeObjectMessage(bool remote)
        {
            Remote = remote;
        }

        public ExchangeObjectMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Remote { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Remote);
        }

        public override void Deserialize(IDataReader reader)
        {
            Remote = reader.ReadBoolean();
        }
    }
}