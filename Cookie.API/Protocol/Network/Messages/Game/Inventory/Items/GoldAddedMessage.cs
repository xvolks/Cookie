using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class GoldAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6030;

        public GoldAddedMessage(GoldItem gold)
        {
            Gold = gold;
        }

        public GoldAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GoldItem Gold { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Gold.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Gold = new GoldItem();
            Gold.Deserialize(reader);
        }
    }
}