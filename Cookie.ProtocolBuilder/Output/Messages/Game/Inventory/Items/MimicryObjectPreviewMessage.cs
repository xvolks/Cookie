namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class MimicryObjectPreviewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6458;
        public override ushort MessageID => ProtocolId;
        public ObjectItem Result { get; set; }

        public MimicryObjectPreviewMessage(ObjectItem result)
        {
            Result = result;
        }

        public MimicryObjectPreviewMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Result.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = new ObjectItem();
            Result.Deserialize(reader);
        }

    }
}
