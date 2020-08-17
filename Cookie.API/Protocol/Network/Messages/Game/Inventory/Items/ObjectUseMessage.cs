namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObjectUseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3019;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public ObjectUseMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectUseMessage() { }

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
