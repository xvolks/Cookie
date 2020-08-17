namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObjectDeletedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3024;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public ObjectDeletedMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectDeletedMessage() { }

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
