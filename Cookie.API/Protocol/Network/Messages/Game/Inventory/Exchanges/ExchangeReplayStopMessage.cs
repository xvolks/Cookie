using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeReplayStopMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6001;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}