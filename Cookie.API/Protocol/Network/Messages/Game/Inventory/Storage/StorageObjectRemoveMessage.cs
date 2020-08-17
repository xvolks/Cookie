namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Storage
{
    using Utils.IO;

    public class StorageObjectRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5648;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public StorageObjectRemoveMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public StorageObjectRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
        }

    }
}
