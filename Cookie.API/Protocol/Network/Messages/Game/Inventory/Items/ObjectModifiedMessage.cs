namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class ObjectModifiedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3029;
        public override ushort MessageID => ProtocolId;
        public ObjectItem Object { get; set; }

        public ObjectModifiedMessage(ObjectItem @object)
        {
            Object = @object;
        }

        public ObjectModifiedMessage() { }

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
