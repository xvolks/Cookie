using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Storage
{
    public class StorageObjectUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5647;

        public StorageObjectUpdateMessage(ObjectItem @object)
        {
            Object = @object;
        }

        public StorageObjectUpdateMessage()
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