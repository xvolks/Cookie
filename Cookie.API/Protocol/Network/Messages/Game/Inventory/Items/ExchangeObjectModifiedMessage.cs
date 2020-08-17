using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ExchangeObjectModifiedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 5519;

        public ExchangeObjectModifiedMessage(ObjectItem @object)
        {
            Object = @object;
        }

        public ExchangeObjectModifiedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ObjectItem Object { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Object = new ObjectItem();
            Object.Deserialize(reader);
        }
    }
}