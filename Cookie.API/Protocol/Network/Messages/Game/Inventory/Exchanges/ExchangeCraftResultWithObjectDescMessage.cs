using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
    {
        public new const ushort ProtocolId = 5999;

        public ExchangeCraftResultWithObjectDescMessage(ObjectItemNotInContainer objectInfo)
        {
            ObjectInfo = objectInfo;
        }

        public ExchangeCraftResultWithObjectDescMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ObjectItemNotInContainer ObjectInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectInfo = new ObjectItemNotInContainer();
            ObjectInfo.Deserialize(reader);
        }
    }
}