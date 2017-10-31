namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Utils.IO;

    public class InventoryPresetItemUpdateErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6211;
        public override ushort MessageID => ProtocolId;
        public byte Code { get; set; }

        public InventoryPresetItemUpdateErrorMessage(byte code)
        {
            Code = code;
        }

        public InventoryPresetItemUpdateErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            Code = reader.ReadByte();
        }

    }
}
