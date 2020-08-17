using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3025;

        public ObjectAddedMessage(ObjectItem @object)
        {
            Object = @object;
        }

        public ObjectAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ObjectItem Object { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Object = new ObjectItem();
            Object.Deserialize(reader);
        }
    }
}