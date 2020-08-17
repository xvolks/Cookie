namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Storage
{
    using Messages.Game.Inventory.Items;
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class StorageInventoryContentMessage : InventoryContentMessage
    {
        public new const ushort ProtocolId = 5646;
        public override ushort MessageID => ProtocolId;

        public StorageInventoryContentMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
